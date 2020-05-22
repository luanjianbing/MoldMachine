/****************************************************************************
** Meta object code from reading C++ file 'RunningStepThread.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.12.3)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../../../RunningStepThread.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'RunningStepThread.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.12.3. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_RunningThread_t {
    QByteArrayData data[18];
    char stringdata0[176];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_RunningThread_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_RunningThread_t qt_meta_stringdata_RunningThread = {
    {
QT_MOC_LITERAL(0, 0, 13), // "RunningThread"
QT_MOC_LITERAL(1, 14, 13), // "stepRunIsDone"
QT_MOC_LITERAL(2, 28, 0), // ""
QT_MOC_LITERAL(3, 29, 12), // "grabImgQuest"
QT_MOC_LITERAL(4, 42, 16), // "excuteImageQuest"
QT_MOC_LITERAL(5, 59, 10), // "emitResMsg"
QT_MOC_LITERAL(6, 70, 3), // "num"
QT_MOC_LITERAL(7, 74, 3), // "tim"
QT_MOC_LITERAL(8, 78, 6), // "result"
QT_MOC_LITERAL(9, 85, 3), // "msg"
QT_MOC_LITERAL(10, 89, 10), // "emitCurMsg"
QT_MOC_LITERAL(11, 100, 11), // "statusInput"
QT_MOC_LITERAL(12, 112, 12), // "statusOutput"
QT_MOC_LITERAL(13, 125, 11), // "progressCur"
QT_MOC_LITERAL(14, 137, 11), // "autoShowRoi"
QT_MOC_LITERAL(15, 149, 15), // "dealInputStatus"
QT_MOC_LITERAL(16, 165, 5), // "dstIn"
QT_MOC_LITERAL(17, 171, 4) // "stus"

    },
    "RunningThread\0stepRunIsDone\0\0grabImgQuest\0"
    "excuteImageQuest\0emitResMsg\0num\0tim\0"
    "result\0msg\0emitCurMsg\0statusInput\0"
    "statusOutput\0progressCur\0autoShowRoi\0"
    "dealInputStatus\0dstIn\0stus"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_RunningThread[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
      10,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       9,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    0,   64,    2, 0x06 /* Public */,
       3,    1,   65,    2, 0x06 /* Public */,
       4,    3,   68,    2, 0x06 /* Public */,
       5,    4,   75,    2, 0x06 /* Public */,
      10,    1,   84,    2, 0x06 /* Public */,
      11,    2,   87,    2, 0x06 /* Public */,
      12,    2,   92,    2, 0x06 /* Public */,
      13,    1,   97,    2, 0x06 /* Public */,
      14,    2,  100,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
      15,    2,  105,    2, 0x08 /* Private */,

 // signals: parameters
    QMetaType::Void,
    QMetaType::Void, QMetaType::Int,    2,
    QMetaType::Void, QMetaType::Int, QMetaType::QString, QMetaType::QString,    2,    2,    2,
    QMetaType::Void, QMetaType::QString, QMetaType::QString, QMetaType::QString, QMetaType::QString,    6,    7,    8,    9,
    QMetaType::Void, QMetaType::QString,    9,
    QMetaType::Void, QMetaType::Int, QMetaType::Int,    2,    2,
    QMetaType::Void, QMetaType::Int, QMetaType::Int,    2,    2,
    QMetaType::Void, QMetaType::Int,    2,
    QMetaType::Void, QMetaType::Int, QMetaType::Int,    2,    2,

 // slots: parameters
    QMetaType::Void, QMetaType::Int, QMetaType::Int,   16,   17,

       0        // eod
};

void RunningThread::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<RunningThread *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->stepRunIsDone(); break;
        case 1: _t->grabImgQuest((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 2: _t->excuteImageQuest((*reinterpret_cast< int(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2])),(*reinterpret_cast< QString(*)>(_a[3]))); break;
        case 3: _t->emitResMsg((*reinterpret_cast< QString(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2])),(*reinterpret_cast< QString(*)>(_a[3])),(*reinterpret_cast< QString(*)>(_a[4]))); break;
        case 4: _t->emitCurMsg((*reinterpret_cast< QString(*)>(_a[1]))); break;
        case 5: _t->statusInput((*reinterpret_cast< int(*)>(_a[1])),(*reinterpret_cast< int(*)>(_a[2]))); break;
        case 6: _t->statusOutput((*reinterpret_cast< int(*)>(_a[1])),(*reinterpret_cast< int(*)>(_a[2]))); break;
        case 7: _t->progressCur((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 8: _t->autoShowRoi((*reinterpret_cast< int(*)>(_a[1])),(*reinterpret_cast< int(*)>(_a[2]))); break;
        case 9: _t->dealInputStatus((*reinterpret_cast< int(*)>(_a[1])),(*reinterpret_cast< int(*)>(_a[2]))); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        {
            using _t = void (RunningThread::*)();
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::stepRunIsDone)) {
                *result = 0;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(int );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::grabImgQuest)) {
                *result = 1;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(int , QString , QString );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::excuteImageQuest)) {
                *result = 2;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(QString , QString , QString , QString );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::emitResMsg)) {
                *result = 3;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(QString );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::emitCurMsg)) {
                *result = 4;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(int , int );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::statusInput)) {
                *result = 5;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(int , int );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::statusOutput)) {
                *result = 6;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(int );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::progressCur)) {
                *result = 7;
                return;
            }
        }
        {
            using _t = void (RunningThread::*)(int , int );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&RunningThread::autoShowRoi)) {
                *result = 8;
                return;
            }
        }
    }
}

QT_INIT_METAOBJECT const QMetaObject RunningThread::staticMetaObject = { {
    &QThread::staticMetaObject,
    qt_meta_stringdata_RunningThread.data,
    qt_meta_data_RunningThread,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *RunningThread::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *RunningThread::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_RunningThread.stringdata0))
        return static_cast<void*>(this);
    return QThread::qt_metacast(_clname);
}

int RunningThread::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QThread::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 10)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 10;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 10)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 10;
    }
    return _id;
}

// SIGNAL 0
void RunningThread::stepRunIsDone()
{
    QMetaObject::activate(this, &staticMetaObject, 0, nullptr);
}

// SIGNAL 1
void RunningThread::grabImgQuest(int _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}

// SIGNAL 2
void RunningThread::excuteImageQuest(int _t1, QString _t2, QString _t3)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)), const_cast<void*>(reinterpret_cast<const void*>(&_t2)), const_cast<void*>(reinterpret_cast<const void*>(&_t3)) };
    QMetaObject::activate(this, &staticMetaObject, 2, _a);
}

// SIGNAL 3
void RunningThread::emitResMsg(QString _t1, QString _t2, QString _t3, QString _t4)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)), const_cast<void*>(reinterpret_cast<const void*>(&_t2)), const_cast<void*>(reinterpret_cast<const void*>(&_t3)), const_cast<void*>(reinterpret_cast<const void*>(&_t4)) };
    QMetaObject::activate(this, &staticMetaObject, 3, _a);
}

// SIGNAL 4
void RunningThread::emitCurMsg(QString _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 4, _a);
}

// SIGNAL 5
void RunningThread::statusInput(int _t1, int _t2)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)), const_cast<void*>(reinterpret_cast<const void*>(&_t2)) };
    QMetaObject::activate(this, &staticMetaObject, 5, _a);
}

// SIGNAL 6
void RunningThread::statusOutput(int _t1, int _t2)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)), const_cast<void*>(reinterpret_cast<const void*>(&_t2)) };
    QMetaObject::activate(this, &staticMetaObject, 6, _a);
}

// SIGNAL 7
void RunningThread::progressCur(int _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 7, _a);
}

// SIGNAL 8
void RunningThread::autoShowRoi(int _t1, int _t2)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(&_t1)), const_cast<void*>(reinterpret_cast<const void*>(&_t2)) };
    QMetaObject::activate(this, &staticMetaObject, 8, _a);
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
