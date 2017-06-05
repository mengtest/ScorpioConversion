using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scorpio.Commons;
using Scorpio.Table;
namespace ScorpioProtoTest {
public class Int2 : IData {
    private bool m_IsInvalid;
    private int _Value1;
    /* <summary>   默认值() </summary> */
    public int getValue1() { return _Value1; }
    private int _Value2;
    /* <summary>   默认值() </summary> */
    public int getValue2() { return _Value2; }
    public object GetData(string key ) {
        if (key == "Value1") return _Value1;
        if (key == "Value2") return _Value2;
        return null;
    }
    public bool IsInvalid() { return m_IsInvalid; }
    private bool IsInvalid_impl() {
        if (!TableUtil.IsInvalid(this._Value1)) return false;
        if (!TableUtil.IsInvalid(this._Value2)) return false;
        return true;
    }
    public override string ToString() {
        return "{ " + 
                "Value1 : " + _Value1 + "," + 
                "Value2 : " + _Value2 + 
                " }";
    }
    public static Int2 Read(TableManager tableManager, String fileName, ScorpioReader reader) {
        Int2 ret = new Int2();
        ret._Value1 = reader.ReadInt32();
        ret._Value2 = reader.ReadInt32();
        ret.m_IsInvalid = ret.IsInvalid_impl();
        return ret;
    }
}
}