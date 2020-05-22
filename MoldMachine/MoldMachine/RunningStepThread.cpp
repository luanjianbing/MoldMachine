#include "RunningStepThread.h"

RunningThread::RunningThread(QObject *parent, int moldId,
	std::map<std::string, std::string> cycleParam,
	std::map<std::string, std::string> imgAddr,
	std::vector<std::vector<std::string>> cycleStep,
	std::vector<std::vector<int>> blockInt,
	std::map<std::string, std::string> ioEnet,
	std::vector<std::vector<std::string>> cycleStepManualNorm,
	std::vector<std::vector<std::string>> cycleStepManualSubCmd,
	std::map<int, int> subRelationIndex,
	std::map<int, int> stepMContinuousInputIdx,
	int runMode)
	: QThread(parent), curMoldObjId(moldId), param(cycleParam), addr(imgAddr), step(cycleStep), block(blockInt), enet(ioEnet),
	stepMNorm(cycleStepManualNorm), stepMSubCmd(cycleStepManualSubCmd), stepMSubIdx(subRelationIndex), 
	stepMCtsInputIdx(stepMContinuousInputIdx), curRunMold(runMode)
{
	//mycam = new Camera();

	//readParam(param, addr, step, block);	//得到map数据跟vector数据

	SimilarityBefore.resize(block.size(), 1);
	SimilarityAfter.resize(block.size(), 1);

	cycle_times = atoi(param["cycle_times"].c_str());
	counter_1 = atoi(param["counter_1"].c_str());
	counter_2 = atoi(param["counter_2"].c_str());
	delay_1 = atoi(param["delay_1"].c_str());
	delay_2 = atoi(param["delay_2"].c_str());

	addr_before = addr["before_ejection"];
	addr_after = addr["after_ejection"];
	grab_addr_before = addr["grab_addr_before"];
	grab_addr_after = addr["grab_addr_after"];
	before_with_block = addr["before_with_block"];
	after_with_block = addr["after_with_block"];

	ioIPAddr = enet["localIP"];
	ioPort = atoi(enet["port"].c_str());

	adamInitRes = adam.Adam6060Init(ioIPAddr, ioPort);
}
 
void RunningThread::run() {
	if (!curRunMold) {		// 按照table步骤运行 curRunMold = 0
		bool cnt_on = 0;
		int cur_cnt = 0;
		//bool next_step_cnt_0 = 0;

		std::string io_in;

		std::string cur_cell;				// 当前遍历单元格数据
		int per_step = step[0].size() - 1;	// 每一步长36

		int cur_step = 0, next_step = 0;
		int for_step = 0;

		cur_step = 1;						// 当前循环步骤
		next_step = atoi(step[cur_step - 1][per_step].c_str());	// 下一步骤

		//std::cout << threadRunFlag << std::endl;
		while (threadRunFlag) {
			//std::cout << cycle_times << std::endl;
			if (!cycle_times) break;

			cur_cell = step[cur_step - 1][28];		// 先获取第一步的第28单元格的数据是否为循环开始
			if (cur_cell == "循环") {
				printCurMsg("本次循环开始");
				while (cycle_times && threadRunFlag) {

					for (int i = 1; i < per_step + 1; i++) {		// 遍历当前步骤所有单元格
						cur_cell = step[cur_step - 1][i];	// 获取当前步骤的cell
						if (cur_cell != "/") {		// 去除为空的单元格
							switch (i)
							{
							case 1:		// 清除输入缓冲器
							{
								//std::cout << "clear input buffer" << std::endl;
								bufferInputClear();
								break;
							}
							case 8:	// 无输入时跳过
							{
								// (TODO)
								std::cout << "skip without input" << std::endl;
								break;
							}
							case 9:	// 按钮
							{
								// (TODO)
								std::cout << "button" << std::endl;
								break;
							}
							case 10:	// 多个计数器
							{
								if (!cnt_on && (cur_cell == "计数1" || cur_cell == "计数2")) {
									cnt_on = 1;
									if (cur_cell == "计数1") {
										cur_cnt = counter_1;
									}
									else if (cur_cell == "计数2") {
										cur_cnt = counter_2;
									}
									std::cout << "cnt start = " << cur_cnt << std::endl;
									//printCurMsg("计数器开始计数");
								}
								else if (cnt_on) {
									cur_cnt--;
									//printCurMsg("计数器减一");
								}
								break;
							}
							case 11:	// 当计数器等于0时跳过
							{
								if (!cur_cnt) {	// cnt = 0
									//printCurMsg("计数器为0，跳至指定步骤");
									next_step = atoi(step[cur_step - 1][i].c_str());
									cnt_on = 0;
								}
								else {
									//printCurMsg("计数器不为0，循环");
									next_step = atoi(step[cur_step - 1][per_step].c_str());
								}
								break;
							}
							case 18:	// 延迟
							{
								if (cur_cell == "延时1") {
									delayTime(delay_1);
								}
								else if (cur_cell == "延时2") {
									delayTime(delay_2);
								}
								break;
							}
							case 25:	// 检查图像
							{
								if (cur_cell == "check") {
									clock_t t = clock();
									checkRes = checkImage();
									//checkRes = 0;
									std::cout << "check : " << double(clock() - t) / CLOCKS_PER_SEC << std::endl;
								}
								break;
							}
							case 26:	// 图像停止时跳过
							{
								if (checkRes)	// 1为检查无误
								{
									if (isNeedManual == 1) 	// 需要人工干预
										printCurMsg("机器自动处理");
									else
										printCurMsg("图像检查无误");
									checkRes = 0;
									//std::cout << "img has satisfied" << std::endl;
								}
								else
								{
									//if (isNeedManual == 1) {	// 需要人工干预
										printCurMsg("图像检查有误，转至异常处理");
										next_step = atoi(step[cur_step - 1][i].c_str());
										//std::cout << "skip with img error" << std::endl;
									//}
									//else {	// 不需要人工干预
									//	// 不转到异常处理，让其继续进行
									//	// 不过让他在图像上显示
									//	printCurMsg("图像检查有误，不需要人工干预");
									//	checkRes = 0;

									//}
								}
								break;
							}
							case 27:	// 图像执行
							{
								excuteImage(cur_cell);
								break;
							}
							case 28:	// 循环
							{
								if (cur_cell == "停止") {	// 检测到循环停止单元
									// 循环异常停止
									// (TODO)
									//cycle_times = 0;
								}
								break;
							}
							case 29:	// 日志
							{
								// (TODO)
								logSaving(cur_cell, for_step);
								//logSaving(cur_cell);
								break;
							}
							case 30:	// 下一步
							{
								emit progressCur(cur_step);
								//std::cout << "--------------------cur step " << cur_step << " over--------------------" << std::endl;
								for_step = cur_step;
								cur_step = next_step;
								next_step = atoi(step[cur_step - 1][per_step].c_str());
								if (cur_cell == "1") { cycle_times--; }	// 如果返回循环起始点，本次循环结束，循环次数减1

								grabImage(0);	// 不选择框
							}
							default:
							{
								if (2 <= i && i <= 7) {		// 输入
									while (threadRunFlag) {
										io_in = getStatus(i - 1);
										if (cur_cell == io_in) {
											break;
										}
									}
								}
								else if (12 <= i && i <= 17) {	// 输出
									if (cur_cell == "启动") {
										setStatus(i - 11, 1);
									}
									else {
										setStatus(i - 11, 0);
									}
								}
								else if (19 <= i && i <= 24) {	// 图像
									if (cur_cell == "grab") {
										grabImage(i - 18);
									}
								}
								break;
							}
							}
						}
					}
				}

			}
			else {
				std::cout << "***can not fine cycle entrance in step 1***" << std::endl;
			}
		}
	}
	else {	// curRunMold = 1 手动输入循环步骤运行
		std::string cur_operation;
		int flagForBeforeOrAfter = 2;

		while (threadRunFlag) {
			if (!cycle_times) break;
			printCurMsg("本次循环开始");
			while (cycle_times && threadRunFlag) {
				for (int i = 0; i < stepMSubIdx[1]; i++) {	// stepMSubIdx中保存着对应ID的起始起点。由于正常的为0，所以去1的起始索引做约束
					emit progressCur(i);
					cur_operation = stepMNorm[i][1];	// 按照手动输入步骤操作
					// 步骤中包括：清除输入缓存、输入、输出、延时、图像、日志操作
					if (cur_operation == "跟踪" || cur_operation == "保存") {
						logSaving(cur_operation, flagForBeforeOrAfter);	// 后面标志位是判定顶出前图像还是顶出后图像,2=qian
					}
					else {	// 输入、输出、图像
						std::vector<std::string> splitWithSharp = split(cur_operation, '#');
						if (splitWithSharp.size() == 4 + 1) {		// IO操作
							//if (splitWithSharp[5] == "0") {		// 正常运行（非多线程）
								if (splitWithSharp[1] == "0") {	// 输出口操作;
									if (splitWithSharp[3] == "1") {		// 1代表启动
										setStatus(atoi(splitWithSharp[2].c_str()), 1);
									}
									else {		// 0代表停止
										setStatus(atoi(splitWithSharp[2].c_str()), 0);
									}
								}
								else if (splitWithSharp[1] == "1") {	// 输入口操作;
									if (stepMCtsInputIdx.find(i) == stepMCtsInputIdx.end()) {
										while (threadRunFlag) {
											std::string io_in = getStatus(atoi(splitWithSharp[2].c_str()));
											if (io_in == "启动") io_in = "1";
											else io_in = "0";
											if (splitWithSharp[3] == io_in) {
												break;
											}
										}
									}
									else {
										// 找到可能需要连续采集输入的起始索引
										int possiableArea = stepMCtsInputIdx[i];	// 取出可能连续存在的区域
																			// 意思就是从i开始连续possiableArea个连续的input
										// 按顺序取出可能需要同时判断的input口
										std::string inputMsg = splitWithSharp[2];	// 首先获取起始的Input口
										std::string inputStatus = splitWithSharp[3];	// 状态
										std::vector<std::string> multiInputSplit;
										std::string multiOpt;
										for (int n = i + 1; n < i + possiableArea; n++) {
											multiOpt = stepMNorm[n][1];
											multiInputSplit = split(multiOpt, '#');
											inputMsg.append(multiInputSplit[2]);
											inputStatus.append(multiInputSplit[3]);
										}
										getPossibleMultiInput(inputMsg, inputStatus);
										i += possiableArea;
									}
								}
						}
						else if (splitWithSharp.size() == 3 + 1) {		// 延时操作
							int tim = atoi(splitWithSharp[2].c_str());
							delayTime(tim);
						}
						else if (splitWithSharp.size() == 2 + 1) {		// 图像操作

							if (splitWithSharp[2] == "检查") {
								if (splitWithSharp[1] == "0") {		// 0代表顶出前图像
									flagForBeforeOrAfter = check_img_forword;	//该标志位用于日志存储用
									beforeSelected = 1;
									afterSelected = 0;
								}
								else if (splitWithSharp[1] == "1") {	// 1代表顶出后图像
									flagForBeforeOrAfter = 6;		// 除2之外的任意一个数都是顶出后
									beforeSelected = 0;
									afterSelected = 1;
								}
								checkRes = checkImage();	// 获取检查结果，当前检查结果为一个bool型
								/*************************子程序处理判断**********************************/
								if (!checkRes) {	// 检查结果不符合要求，并且detailCheckRes已经更新了条件
									// 根据i和条件condition获取子程序入口和动作
									int dstIdx = 0, dstSubIdx = 0, dstSubStartIdx = 0, dstSubOverIdx = 0;
									for (; dstIdx < stepMSubCmd.size(); ++dstIdx) {
										if ((i + 1) == atoi(stepMSubCmd[dstIdx][0].c_str()) && detailCheckRes == stepMSubCmd[dstIdx][3]) {
											break;
										}
									}
									// 找到子程序入口
									dstSubIdx = atoi(stepMSubCmd[dstIdx][2].c_str());
									dstSubStartIdx = stepMSubIdx[dstSubIdx];	// 起始索引
									dstSubOverIdx = stepMSubIdx[dstSubIdx + 1];	// 截至索引
									// 根据找到的dstIdx判断
									std::string subCurOperation = "";
									for (int j = dstSubStartIdx; j < dstSubOverIdx; ++j) {
										subCurOperation = stepMNorm[j][1];
										if (subCurOperation == "跟踪" || subCurOperation == "保存") {
											logSaving(subCurOperation, flagForBeforeOrAfter);	// 后面标志位是判定顶出前图像还是顶出后图像,2=qian
										}
										else {	// 输入、输出、图像
											std::vector<std::string> splitWithSharpSub = split(subCurOperation, '#');
											if (splitWithSharpSub.size() == 4 + 1) {		// IO操作
																							//if (splitWithSharp[5] == "0") {		// 正常运行（非多线程）
												if (splitWithSharpSub[1] == "0") {	// 输出口操作;
													if (splitWithSharpSub[3] == "1") {		// 1代表启动
														setStatus(atoi(splitWithSharpSub[2].c_str()), 1);
													}
													else {		// 0代表停止
														setStatus(atoi(splitWithSharpSub[2].c_str()), 0);
													}
												}
												else if (splitWithSharpSub[1] == "1") {	// 输入口操作;
													while (threadRunFlag) {
														std::string io_in = getStatus(atoi(splitWithSharpSub[2].c_str()));
														if (io_in == "启动") io_in = "1";
														else io_in = "0";
														if (splitWithSharpSub[3] == io_in) {
															break;
														}
													}
												}
											}
											else if (splitWithSharpSub.size() == 3 + 1) {		// 延时操作
												int tim = atoi(splitWithSharpSub[2].c_str());
												delayTime(tim);
											}
											else if (splitWithSharpSub.size() == 2 + 1) {
												if (splitWithSharpSub[2] == "暂停" || splitWithSharpSub[2] == "显示" || splitWithSharpSub[2] == "清除") {	// 图像执行操作
													beforeSelected = 1;
													afterSelected = 1;
													excuteImage(splitWithSharpSub[2]);
												}
											}
											while (!splitWithSharpSub.empty()) {
												splitWithSharpSub.pop_back();
											}
										}
									}
									if (stepMSubCmd[dstIdx][1] == "jump") {	// 跳跃
										// jump 会继续往下执行，即沿着原来的路线继续执行
									}
									else if (stepMSubCmd[dstIdx][1] == "over") {	// 结束
										// over 会终止
										cycle_times = 1;
										break;
									}
								}
								/*************************子程序处理判断**********************************/
							}
							else if (splitWithSharp[2] == "暂停" || splitWithSharp[2] == "显示" || splitWithSharp[2] == "清除") {	// 图像执行操作
								beforeSelected = 1;
								afterSelected = 1;
								excuteImage(splitWithSharp[2]);
							}
						}

						while (!splitWithSharp.empty()) {
							splitWithSharp.pop_back();
						}
					}
					
				}
				cycle_times--;
			}
		}
	}

	// 循环结束
	//delete mycam;
	emit stepRunIsDone();	
}

// 按单个字符分割字符串
std::vector<std::string> RunningThread::split(std::string s, char delim) {
	std::vector<std::string> v;
	std::stringstream stringstream1(s);
	std::string tmp;
	while (getline(stringstream1, tmp, delim)) {
		v.push_back(tmp);
	}
	return v;
}

void RunningThread::getPossibleMultiInput(std::string inputMsg, std::string inputStatus) {
	// inputMsg是按顺序可能需要连续判断的input口的编号如"21"，并且2口在前
	// inputStatus是需要接受的对应状态如"01"
	// 求掩码mask
	int mask = 0;
	int sumRes = 0;
	int getRes = 0;
	for (auto c : inputMsg) {
		mask += 1 << (c - '0' - 1);
		sumRes = sumRes << 1 + (c - '0');
	}
	// (TODO)
	//do {
	//	getRes = adam.Adam6060ReadAllStatus(mask);
	//} while (getRes != sumRes);
	
}

// 8个输入状态read
std::string RunningThread::getStatus(int dstIO) {
	// (TODO) 输入状态用定时器判断
	std::string msg = "正在等待输入口";
	printCurMsg(msg.append(std::to_string(dstIO)).append("切换状态..."));

	std::string status;

	while (!hasGetIn && threadRunFlag);	// 未接收到信息

	// 跳过说明接收到信息
	hasGetIn = 0;
	status = std::to_string(getInStus);

	//(TODO)
	//if (!adamInitRes)	status = std::to_string(adam.Adam6060ReadStatus(dstIO));

	emit statusInput(dstIO, atoi(status.c_str()));

	return status == "1" ? "启动":"停止";
}

void RunningThread::dealInputStatus(int dstIn,int stus) {
	getInIO = dstIn;
	getInStus = stus;
	hasGetIn = 1;
}

// 8个输出状态set
void RunningThread::setStatus(int dstIO, bool status) {
	std::string msg = "正在控制输出口";
	printCurMsg(msg.append(std::to_string(dstIO)).append("切换状态"));

	//(TODO)
	if (adamInitRes)
		adam.Adam6060SingleSetOut(dstIO, status);

	emit statusOutput(dstIO, status);
}

void RunningThread::delayTime(int time) {
	printCurMsg("延时中...");
	std::cout << "delay " << time << " ms" << std::endl;
	// 延时代码
	//sleep(time);
	_sleep(time);
}

void RunningThread::grabImage(int dstIO) {
	printCurMsg("正在抓取图像...");
	switch (dstIO)
	{
		case 1:
		{
			//shotPicture(grabImageBefore);
			//cv::imwrite(grab_addr_before, grabImageBefore);
			beforeSelected = 1;
			emit grabImgQuest(dstIO);
			//std::cout << dstIO << ":" << "img_select" << std::endl;
			break;
		}
		case 2:
		{
			//shotPicture(grabImageAfter);
			//cv::imwrite(grab_addr_after, grabImageAfter);
			afterSelected = 1;
			emit grabImgQuest(dstIO);
			//std::cout << dstIO << ":" << "img_select" << std::endl;
			break;
		}
		default:
		{
			beforeSelected = 0;
			afterSelected = 0;
			emit grabImgQuest(dstIO);
			break;
		}
	}
}

bool RunningThread::checkImage() {
	detailCheckRes = "正常";
	bool res = 0;
	double similarity = 0;

	if (beforeSelected) {
		printCurMsg("正在检查顶出前图像...");

		shotPicture(grabImageBefore);
		//cv::imwrite(grab_addr_before, grabImageBefore);

		picBeforeEjection = cv::imread(addr_before);
		ImageProcessing imgProcess(picBeforeEjection, grabImageBefore, block);
		SimilarityBefore = imgProcess.compareFacesByHist(picBeforeEjection, grabImageBefore);

		std::cout << "check before ejection image" << std::endl;

		//// 测试检测后某区域为0
		//SimilarityBefore[5] = 0;

		for (int i = 0; i < SimilarityBefore.size(); i++) {
			std::cout << i << ":" << SimilarityBefore[i] << std::endl;
		}

		clock_t t = clock();
		cv::imwrite(grab_addr_before, grabImageBefore);			// 无block
		std::cout << "imwrite grab img : " << double(clock() - t) / CLOCKS_PER_SEC << std::endl;

		clock_t t1 = clock();
		cv::Mat beforeC = grabImageBefore.clone();
		for (int i = 0; i < block.size(); i++) {
			switch (block[i][5])		//	shapeid
			{
			case 0:		// 矩形
			{
				if (SimilarityBefore[i] >= SimilarityMin) {
					cv::rectangle(beforeC, cv::Rect(block[i][0], block[i][1],
						block[i][2], block[i][3]), CvScalar(255, 0, 0), 8, cv::LINE_8, 0);
				}
				else {
					cv::rectangle(beforeC, cv::Rect(block[i][0], block[i][1],
						block[i][2], block[i][3]), CvScalar(0, 0, 255), 8, cv::LINE_8, 0);
				}
				break;
			}
			case 1:		// 圆形
			{
				int lAxis = block[i][2] / 2;
				int sAxis = block[i][3] / 2;
				int cX = block[i][0] + lAxis;
				int cY = block[i][1] + sAxis;

				if (SimilarityBefore[i] >= SimilarityMin) {
					cv::ellipse(beforeC, cv::Point(cX, cY), cv::Size(lAxis, sAxis), 0, 0, 360, CvScalar(255, 0, 0), 8, cv::LINE_8);
				}
				else {
					cv::ellipse(beforeC, cv::Point(cX, cY), cv::Size(lAxis, sAxis), 0, 0, 360, CvScalar(0, 0, 255), 8, cv::LINE_8);
				}
				break;
			}
			case 2:		// 三角形
			{
				cv::Point points[1][3];
				points[0][0] = cv::Point(block[i][0], block[i][1] + block[i][3]);
				points[0][1] = cv::Point(block[i][0] + block[i][2] / 2, block[i][1]);
				points[0][2] = cv::Point(block[i][0] + block[i][2], block[i][1] + block[i][3]);
				const cv::Point *pts[1] = { points[0] };
				int npt[] = { 3 };

				if (SimilarityBefore[i] >= SimilarityMin) {
					cv::polylines(beforeC, pts, npt, 1, true, cv::Scalar(255, 0, 0), 8);
				}
				else {
					cv::polylines(beforeC, pts, npt, 1, true, cv::Scalar(0, 0, 255), 8);
				}
				break;
			}
			case 3:		// 菱形
			{
				cv::Point points[1][4];
				points[0][0] = cv::Point(block[i][0], block[i][1] + block[i][3] / 2);
				points[0][1] = cv::Point(block[i][0] + block[i][2] / 2, block[i][1]);
				points[0][2] = cv::Point(block[i][0] + block[i][2], block[i][1] + block[i][3] / 2);
				points[0][3] = cv::Point(block[i][0] + block[i][2] / 2, block[i][1] + block[i][3]);
				const cv::Point *pts[1] = { points[0] };
				int npt[] = { 4 };

				if (SimilarityBefore[i] >= SimilarityMin) {
					cv::polylines(beforeC, pts, npt, 1, true, cv::Scalar(255, 0, 0), 8);
				}
				else {
					cv::polylines(beforeC, pts, npt, 1, true, cv::Scalar(0, 0, 255), 8);
				}
				break;
			}
			default:
				break;
			}
		}
		std::cout << "draw block : " << double(clock() - t1) / CLOCKS_PER_SEC << std::endl;
		clock_t t2 = clock();
		cv::imwrite(before_with_block, beforeC);
		std::cout << "imwrite block : " << double(clock() - t2) / CLOCKS_PER_SEC << std::endl;
	}
	else if (afterSelected) {
		printCurMsg("正在检查顶出后图像...");

		shotPicture(grabImageAfter);
		//cv::imwrite(grab_addr_after, grabImageAfter);

		picAfterEjection = cv::imread(addr_after);
		ImageProcessing imgProcess(picAfterEjection, grabImageAfter, block);
		SimilarityAfter = imgProcess.compareFacesByHist(picAfterEjection, grabImageAfter);

		std::cout << "check after ejection image" << std::endl;

		for (int i = 0; i < SimilarityAfter.size(); i++) {
			std::cout << i << ":" << SimilarityAfter[i] << std::endl;
		}

		cv::imwrite(grab_addr_after, grabImageAfter);

		cv::Mat afterC = grabImageAfter.clone();
		for (int i = 0; i < block.size(); i++) {
			switch (block[i][5])		//	shapeid
			{
			case 0:		// 矩形
			{
				if (SimilarityAfter[i] >= SimilarityMin) {
					cv::rectangle(afterC, cv::Rect(block[i][0], block[i][1],
						block[i][2], block[i][3]), CvScalar(255, 0, 0), 8, cv::LINE_8, 0);
				}
				else {
					cv::rectangle(afterC, cv::Rect(block[i][0], block[i][1],
						block[i][2], block[i][3]), CvScalar(0, 0, 255), 8, cv::LINE_8, 0);
				}
				break;
			}
			case 1:		// 圆形
			{
				int lAxis = block[i][2] / 2;
				int sAxis = block[i][3] / 2;
				int cX = block[i][0] + lAxis;
				int cY = block[i][1] + sAxis;

				if (SimilarityAfter[i] >= SimilarityMin) {
					cv::ellipse(afterC, cv::Point(cX, cY), cv::Size(lAxis, sAxis), 0, 0, 360, CvScalar(255, 0, 0), 8, cv::LINE_8);
				}
				else {
					cv::ellipse(afterC, cv::Point(cX, cY), cv::Size(lAxis, sAxis), 0, 0, 360, CvScalar(0, 0, 255), 8, cv::LINE_8);
				}
				break;
			}
			case 2:		// 三角形
			{
				cv::Point points[1][3];
				points[0][0] = cv::Point(block[i][0], block[i][1] + block[i][3]);
				points[0][1] = cv::Point(block[i][0] + block[i][2] / 2, block[i][1]);
				points[0][2] = cv::Point(block[i][0] + block[i][2], block[i][1] + block[i][3]);
				const cv::Point *pts[1] = { points[0] };
				int npt[] = { 3 };

				if (SimilarityAfter[i] >= SimilarityMin) {
					cv::polylines(afterC, pts, npt, 1, true, cv::Scalar(255, 0, 0), 8);
				}
				else {
					cv::polylines(afterC, pts, npt, 1, true, cv::Scalar(0, 0, 255), 8);
				}
				break;
			}
			case 3:		// 菱形
			{
				cv::Point points[1][4];
				points[0][0] = cv::Point(block[i][0], block[i][1] + block[i][3] / 2);
				points[0][1] = cv::Point(block[i][0] + block[i][2] / 2, block[i][1]);
				points[0][2] = cv::Point(block[i][0] + block[i][2], block[i][1] + block[i][3] / 2);
				points[0][3] = cv::Point(block[i][0] + block[i][2] / 2, block[i][1] + block[i][3]);
				const cv::Point *pts[1] = { points[0] };
				int npt[] = { 4 };

				if (SimilarityAfter[i] >= SimilarityMin) {
					cv::polylines(afterC, pts, npt, 1, true, cv::Scalar(255, 0, 0), 8);
				}
				else {
					cv::polylines(afterC, pts, npt, 1, true, cv::Scalar(0, 0, 255), 8);
				}
				break;
			}
			default:
				break;
			}
			//if (similarity[i] >= 0.9) {
			//	cv::rectangle(afterC, cv::Rect(block[i][0], block[i][1],
			//		block[i][2], block[i][3]), CvScalar(255, 0, 0), 8, cv::LINE_8, 0);
			//}
			//else {
			//	cv::rectangle(afterC, cv::Rect(block[i][0], block[i][1],
			//		block[i][2], block[i][3]), CvScalar(0, 0, 255), 8, cv::LINE_8, 0);
			//}
		}
		
		cv::imwrite(after_with_block, afterC);
	}

	//// 目前判断只需要小于min就必须人工干预
	//if (beforeSelected)
	//{
	//	for (int i = 0; i < SimilarityBefore.size(); i++) {
	//		if (SimilarityBefore[i] < SimilarityMin) {
	//			//res = 0;
	//			isNeedManual = 1;
	//			break;
	//		}
	//		else {
	//			//res = 1;
	//			isNeedManual = 0;
	//		}
	//	}
	//}
	//else if (afterSelected) {
	//	for (int i = 0; i < SimilarityAfter.size(); i++) {
	//		if (SimilarityAfter[i] < SimilarityMin) {
	//			//res = 0;
	//			isNeedManual = 1;
	//			break;
	//		}
	//		else {
	//			//res = 1;
	//			isNeedManual = 0;
	//		}
	//	}
	//}
	// 额外判断是否需要人工干预
	std::vector<int> errorIdBefore, errorIdAfter;
	
	if (beforeSelected)
	{
		for (int i = 0; i < SimilarityBefore.size(); i++) {
			if (SimilarityBefore[i] < SimilarityMin) {
				// 细化找到错误集合
				errorIdBefore.push_back(i);
			}
		}
	}
	else if (afterSelected) {
		for (int i = 0; i < SimilarityAfter.size(); i++) {
			if (SimilarityAfter[i] < SimilarityMin) {
				// 细化找到错误集合
				errorIdAfter.push_back(i);
			}
		}
	}

	isNeedManual = 0;	// 初始化.
	isSuccess = 0;
	// 对错误集合进行判断处理
	if (!errorIdBefore.empty() || !errorIdAfter.empty()) {
		// 有错误需要进一步判断
		res = 0;	// 有误
		isNeedManual = isNeedManualForDetail(errorIdBefore, errorIdAfter);	// 判断是否需要人工干预
		// 如果不需要人工干预则给出信号
		if (!isNeedManual) {
			// (TODO)给出信号
			// 这里给出如"缺角""划痕"等一系列机器自动处理的信号
			std::cout << "give out signal no need manual" << std::endl;
		}
		else {
			// 这里给出如"残留"等一系列需要人工干预的信号
			detailCheckRes = "人工干预";
			std::cout << "wait for manual" << std::endl;
		}
		res = !isNeedManual;// res = 0为需要人工干预
	//						// res = 1为不需要人工干预，机器自动处理
	}
	else {
		// 无误
		isSuccess = 1;	// 成功状态用于最后日志存储那块
		res = 1;	// 无误
	}
	//// 将错误集合进一步判断是否需要人工处理
	//isNeedManual = isNeedManualForDetail(errorId);
	//// res = isNeedManual取反结果
	//res = ~isNeedManual;	// res = 0为需要人工干预
	//						// res = 1为不需要人工干预

	return res;
}

// 细化检测
bool RunningThread::isNeedManualForDetail(std::vector<int> errorNumB, std::vector<int> errorNumA) {
	// 对含有错误的区域进行进一步分析需不需要人工干预
	std::cout << "find error area, start to analyse" << std::endl;
	// （TODO）
	if (!errorNumB.empty()) {
		//autoShowRoi(0, errorNumB[errorNumB.size() - 1]);
		// ...

	}
	else if (!errorNumA.empty()) {
		//autoShowRoi(0, errorNumA[errorNumA.size() - 1]);
	}

	// （TODO）将判断结果后的需要自动处理的区域压入noNeedManualArea中，送给机器自动处理
	// 当前将所有都认为不需要人工干预，即机器自动处理

	noNeedManualAreaB = errorNumB;
	noNeedManualAreaA = errorNumA;

	// （TODO）发出信号给机器手，调取指定模具进行修补
	// ...

	// 返回固定值 0，不需要人工干预
	return 1;
}

void RunningThread::excuteImage(std::string cur) {
	//std::cout << "excute img " << std::endl;
	if (cur == "显示") {
		printCurMsg("显示已选择图像");
		if (beforeSelected && afterSelected) {
			emit excuteImageQuest(1, QString::fromStdString(before_with_block), QString::fromStdString(after_with_block));	// 显示所有图片	
		}
		else if(beforeSelected && !afterSelected){
			emit excuteImageQuest(4, QString::fromStdString(before_with_block), QString::fromStdString(after_with_block));	// 显示顶出前图像
		}
		else if (afterSelected && !beforeSelected) {
			emit excuteImageQuest(5, QString::fromStdString(before_with_block), QString::fromStdString(after_with_block));	// 显示顶出后图像
		}
		//emit curCycleIsDone();		// 显示图像
	}
	else if (cur == "暂停") {
		printCurMsg("正在更新记忆图像...");
		// 判断选择抓取的图片能否取代原先比较的图片
		// grabImageBefore能否取代picBeforeEjection
		// grabImageAfter能否取代picAfterEjection
		if (beforeSelected && afterSelected) {
			dealExcuteImagePause(grabImageBefore, picBeforeEjection);
			dealExcuteImagePause(grabImageAfter, picAfterEjection);
			cv::imwrite(addr_before, picBeforeEjection);
			cv::imwrite(addr_after, picAfterEjection);
		}
		else if (beforeSelected && !afterSelected) {
			dealExcuteImagePause(grabImageBefore, picBeforeEjection);
			cv::imwrite(addr_before, picBeforeEjection);
		}
		else if (afterSelected && !beforeSelected) {
			dealExcuteImagePause(grabImageAfter, picAfterEjection);
			cv::imwrite(addr_after, picAfterEjection);
		}
		emit excuteImageQuest(2, QString::fromStdString(before_with_block), QString::fromStdString(after_with_block));
	}
	else if (cur == "清除") {
		printCurMsg("清除图像");
		emit excuteImageQuest(3, QString::fromStdString(before_with_block), QString::fromStdString(after_with_block));
	}
}

void RunningThread::dealExcuteImagePause(cv::Mat &pic1, cv::Mat &pic2) {
	// 判断pic1能否取代pic2
	pic2 = pic1;
	//pic2 = cv::imread("./Resources/image/toUpdateImg.png");
}

void RunningThread::shotPicture(cv::Mat &picture) {
	//mycam->matImg_1.copyTo(picture);
	picture = cv::imread("./Resources/image/before_ejection.png");
}

void RunningThread::logSaving(std::string log_message, int for_step) {
	printCurMsg("正在进行结果存储...");

	std::cout << "run on log saving" << std::endl;
	MysqlSetting mysql_con;

	time_t rawtime;
	struct tm *ptminfo;

	time(&rawtime);
	ptminfo = localtime(&rawtime);
	std::string dt, date_save;
	std::string _year = std::to_string(ptminfo->tm_year + 1900);
	std::string _month = std::to_string(ptminfo->tm_mon + 1);
	std::string _day = std::to_string(ptminfo->tm_mday);
	std::string _hour = std::to_string(ptminfo->tm_hour);
	std::string _min = std::to_string(ptminfo->tm_min);
	std::string _second = std::to_string(ptminfo->tm_sec);

	// 拼接当前时间dt
	dt.append(_year).append("-").append(_month).append("-").append(_day).append(" ").append(_hour).append(":").append(_min).append(":").append(_second);

	//resMsg = dt;

	// (TODO)信息存入数据库，以及logErrorImageNum初值应该是数据库中错误的信息的已有个数
	if (log_message == "跟踪") {		
		//std::cout << "success in this cycle" << std::endl;

		// 将不需要人工干预，机器自动处理作为成功状态的一种
		if (isSuccess) {	// 成功无误
			// 成功完成一次循环，记录信息
			mysql_con.insertLogData("log", dt, "sucess", "");
			printResMsg(std::to_string(atoi(param["cycle_times"].c_str()) - cycle_times + 1), dt, "成功", "");
		}
		else {	// 成功但是存在故障区域，不需要人工，自动处理
			mysql_con.insertLogData("log", dt, "auto", "");
			printResMsg(std::to_string(atoi(param["cycle_times"].c_str()) - cycle_times + 1), dt, "存在故障", "自动处理");
		}
	}
	else if (log_message == "保存") {
		// 出现异常，保存信息与错误图片，库内存入地址
		//logErrorImageNum++;

		date_save.append(_year).append("-").append(_month).append("-").append(_day).append("_").append(_hour).append("'").append(_min).append("'").append(_second);

		std::string addr_error = "./Resources/log_error_image";
		
		if (for_step == check_img_forword) {
			addr_error.append("/BJ_").append(date_save).append(".png");
			cv::imwrite(addr_error, grabImageBefore);
			printResMsg(std::to_string(atoi(param["cycle_times"].c_str()) - cycle_times + 1), dt, "人工干预等待", "顶出前故障");
		}
		else {
			addr_error.append("/AJ_").append(date_save).append(".png");
			cv::imwrite(addr_error, grabImageAfter);
			printResMsg(std::to_string(atoi(param["cycle_times"].c_str()) - cycle_times + 1), dt, "人工干预等待", "顶出后故障");
		}

		mysql_con.insertLogData("log", dt, "fail", addr_error);
		//if (logErrorImageTotal == logErrorImageNum) logErrorImageNum = 0;	// 限定保存logErrorImageTotal张错误图片

		//std::cout << "fail in this cycle" << std::endl;
		
	}
	
	// 存储相似度到数据库 
	std::vector<std::vector<std::string>> vect_similarity;
	vect_similarity.resize(SimilarityBefore.size());
	for (int i = 0; i < vect_similarity.size(); i++) {
		vect_similarity[i].resize(3);
		if (beforeSelected) vect_similarity[i][0] = std::to_string(SimilarityBefore[i]);
		if (afterSelected) vect_similarity[i][1] = std::to_string(SimilarityAfter[i]);
		vect_similarity[i][2] = std::to_string(curMoldObjId);
	}
	mysql_con.detStepIdAndNewData("image_block_msg", vect_similarity, curMoldObjId);
	
	int flagBOrA = -1;	// 顶出前还是顶出后
	int flagNum = -1;	// 第几个出现问题
	for (int i = 0; i < vect_similarity.size(); i++) {
		for (int j = 0; j < 2; j++) {
			if (std::stod(vect_similarity[i][j]) < SimilarityMin) {
				flagBOrA = j;	// 0为顶出前，1为顶出后
				flagNum = i;	// 第几个
			}
		}
	}
	std::cout << "flagBOrA: " << flagBOrA << "flagNum: " << flagNum << std::endl;
	
	if (isNeedManual) {			// 当isNeedManual不为0
		// 显示有故障区域的最后一个区域
		if (flagBOrA != -1) {
			autoShowRoi(flagBOrA, flagNum);
		}
	}
}

void RunningThread::bufferInputClear() {
	// (TODO)
	printCurMsg("清除输入缓冲");
}

void RunningThread::setRunFlag(bool run_flag) {
	threadRunFlag = run_flag;
}

void RunningThread::printResMsg(std::string num, std::string tim, std::string result, std::string msg) {
	emit emitResMsg(QString::fromStdString(num), QString::fromStdString(tim), QString::fromStdString(result), QString::fromStdString(msg));
}

void RunningThread::printCurMsg(std::string msg) {
	emit emitCurMsg(QString::fromStdString(msg));
}

void RunningThread::stopThread() {
	this->setRunFlag(0);
	this->quit();
	this->wait();
}

//void RunningThread::findMultiInput(std::map<int, int> &msgInput) {
//	std::string curOpt;
//	std::vector<std::string> splitWithSharp;
//	for (int i = 0; i < stepMNorm.size(); i++) {
//		curOpt = stepMNorm[i][1];
//		splitWithSharp = split(curOpt, '#');
//		if (splitWithSharp.size() == 4 + 1) {	// 对IO进行判断
//			if (splitWithSharp[1] == "1") {	// 输入
//
//			}
//		}
//		while (!splitWithSharp.empty()) {
//			splitWithSharp.pop_back();
//		}
//	}
//}


RunningThread::~RunningThread() {
	stopThread();
}