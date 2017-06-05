//本文件为自动生成，请不要手动修改
package ScorpioProtoTest;
import java.util.HashMap;
import Scorpio.Message.IMessage;
@SuppressWarnings("serial")
public class MessageManager {
    public static final IMessage parseByteToMsg(int msgType, byte[] buff) {
        switch (msgType) {
        case 0: return Msg_C2G_Test.Deserialize(buff);
        case 1: return Msg_C2G_Test2.Deserialize(buff);
        case 2: return Msg_C2G_Test3.Deserialize(buff);
        default: throw new RuntimeException("找不到MsgType : " + msgType);
        }
    };
    public static final HashMap<String, Integer> MessageToID = new HashMap<String, Integer>() {
        {
            put("Msg_C2G_Test", 0);
            put("Msg_C2G_Test2", 1);
            put("Msg_C2G_Test3", 2);
        }
    };
    public static final HashMap<Integer, String> IDToMessage = new HashMap<Integer, String>() {
        {
            put(0, "Msg_C2G_Test");
            put(1, "Msg_C2G_Test2");
            put(2, "Msg_C2G_Test3");
        }
    };
    public static final HashMap<Integer, Class<?>> IDToType = new HashMap<Integer, Class<?>>() {
        {
            put(0, Msg_C2G_Test.class);
            put(1, Msg_C2G_Test2.class);
            put(2, Msg_C2G_Test3.class);
        }
    };
    public static final HashMap<Class<?>, Integer> TypeToID = new HashMap<Class<?>, Integer>() {
        {
            put(Msg_C2G_Test.class, 0);
            put(Msg_C2G_Test2.class, 1);
            put(Msg_C2G_Test3.class, 2);
        }
    };
    public static final HashMap<Integer, IMessage> IDToObject = new HashMap<Integer, IMessage>() {
        {
            put(0, new Msg_C2G_Test());
            put(1, new Msg_C2G_Test2());
            put(2, new Msg_C2G_Test3());
        }
    };
}