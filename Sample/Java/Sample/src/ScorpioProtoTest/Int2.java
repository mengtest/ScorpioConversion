package ScorpioProtoTest;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import Scorpio.Commons.*;
import Scorpio.Table.*;
@SuppressWarnings("unused")
public class Int2 implements IData {
    private boolean m_IsInvalid = false;
    private Integer _Value1;
    /**   默认值() */
    public Integer getValue1() { return _Value1; }
    private Integer _Value2;
    /**   默认值() */
    public Integer getValue2() { return _Value2; }
    public Object GetData(String key ) {
        if (key.equals("Value1")) return _Value1;
        if (key.equals("Value2")) return _Value2;
        return null;
    }
    public boolean IsInvalid() { return m_IsInvalid; }
    private boolean IsInvalid_impl() {
        if (!TableUtil.IsInvalid(this._Value1)) return false;
        if (!TableUtil.IsInvalid(this._Value2)) return false;
        return true;
    }
    @Override
    public String toString() {
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