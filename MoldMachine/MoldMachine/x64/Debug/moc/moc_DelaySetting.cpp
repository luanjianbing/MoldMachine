/****************************************************************************
** Meta object code from reading C++ file 'DelaySetting.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.12.3)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../../../DelaySetting.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'DelaySetting.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.12.3. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_DelaySetting_t {
    QByteArrayData data[15];
    char stringdata0[251];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_DelaySetting_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_DelaySetting_t qt_meta_stringdata_DelaySetting = {
    {
QT_MOC_LITERAL(0, 0, 12), // "DelaySetting"
QT_MOC_LITERAL(1, 13, 17), // "buttonSureClicked"
QT_MOC_LITERAL(2, 31, 0), // ""
QT_MOC_LITERAL(3, 32, 19), // "buttonSwitchClicked"
QT_MOC_LITERAL(4, 52, 18), // "buttonClearClicked"
QT_MOC_LITERAL(5, 71, 17), // "buttonZeroClicked"
QT_MOC_LITERAL(6, 89, 16), // "buttonOneClicked"
QT_MOC_LITERAL(7, 106, 16), // "buttonTwoClicked"
QT_MOC_LITERAL(8, 123, 18), // "buttonThreeClicked"
QT_MOC_LITERAL(9, 142, 17), // "buttonFourClicked"
QT_MOC_LITERAL(10, 160, 17), // "buttonFiveClicked"
QT_MOC_LITERAL(11, 178, 16), // "buttonSixClicked"
QT_MOC_LITERAL(12, 195, 18), // "buttonSevenClicked"
QT_MOC_LITERAL(13, 214, 18), // "buttonEightClicked"
QT_MOC_LITERAL(14, 233, 17) // "buttonNineClicked"

    },
    "DelaySetting\0buttonSureClicked\0\0"
    "buttonSwitchClicked\0buttonClearClicked\0"
    "buttonZeroClicked\0buttonOneClicked\0"
    "buttonTwoClicked\0buttonThreeClicked\0"
    "buttonFourClicked\0buttonFiveClicked\0"
    "buttonSixClicked\0buttonSevenClicked\0"
    "buttonEightClicked\0buttonNineClicked"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_DelaySetting[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
      13,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   79,    2, 0x08 /* Private */,
       3,    0,   80,    2, 0x08 /* Private */,
       4,    0,   81,    2, 0x08 /* Private */,
       5,    0,   82,    2, 0x08 /* Private */,
       6,    0,   83,    2, 0x08 /* Private */,
       7,    0,   84,    2, 0x08 /* Private */,
       8,    0,   85,    2, 0x08 /* Private */,
       9,    0,   86,    2, 0x08 /* Private */,
      10,    0,   87,    2, 0x08 /* Private */,
      11,    0,   88,    2, 0x08 /* Private */,
      12,    0,   89,    2, 0x08 /* Private */,
      13,    0,   90,    2, 0x08 /* Private */,
      14,    0,   91,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void DelaySetting::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<DelaySetting *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->buttonSureClicked(); break;
        case 1: _t->buttonSwitchClicked(); break;
        case 2: _t->buttonClearClicked(); break;
        case 3: _t->buttonZeroClicked(); break;
        case 4: _t->buttonOneClicked(); break;
        case 5: _t->buttonTwoClicked(); break;
        case 6: _t->buttonThreeClicked(); break;
        case 7: _t->buttonFourClicked(); break;
        case 8: _t->buttonFiveClicked(); break;
        case 9: _t->buttonSixClicked(); break;
        case 10: _t->buttonSevenClicked(); break;
        case 11: _t->buttonEightClicked(); break;
        case 12: _t->buttonNineClicked(); break;
        default: ;
        }
    }
    Q_UNUSED(_a);
}

QT_INIT_METAOBJECT const QMetaObject DelaySetting::staticMetaObject = { {
    &QWidget::staticMetaObject,
    qt_meta_stringdata_DelaySetting.data,
    qt_meta_data_DelaySetting,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *DelaySetting::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *DelaySetting::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_DelaySetting.stringdata0))
        return static_cast<void*>(this);
    return QWidget::qt_metacast(_clname);
}

int DelaySetting::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 13)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 13;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 13)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 13;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
