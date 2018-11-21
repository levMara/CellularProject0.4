using Common.Enum;

namespace Common
{
    public class ClientType
    {
        public int ClientTypeID { get; set; }
        public double MinuteRate { get; set; }
        public double SmsRate { get; set; }

        //public virtual ClientTypeName TypeName { get; set; }
    }
}