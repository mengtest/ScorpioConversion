using Scorpio.Commons;
namespace Scorpio.Message {
    public abstract class IMessage {
        protected int __Sign = 0;
        protected void AddSign(int index) {
            __Sign = ScorpioUtil.AddSign(__Sign, index);
        }
        public bool HasSign(int index) {
            return ScorpioUtil.HasSign(__Sign, index);
        }
        public byte[] Serialize() {
            ScorpioWriter writer = new ScorpioWriter();
            Write(writer);
            return writer.ToArray();
        }
        public void Parser(byte[] buffer) {
            Read(new ScorpioReader(buffer));
        }
        public abstract void Write(ScorpioWriter writer);
        public abstract void Read(ScorpioReader reader);
        public abstract IMessage New();
    }
}