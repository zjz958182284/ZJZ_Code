using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
  [Serializable]
   public class Receiver
    {
        private string receiverID;
        private string receiverName;
        private string receiverAddress;
        private string receiverPhone;
        public Receiver() { }
        public string ReceiverID
        {
            get => receiverID;
            set => receiverID = value;
        }
        public string ReceiverName
        {
            get => receiverName;
            set => receiverName = value;
        }
        public string ReceiverAddress
        {
            get => receiverAddress;
            set => receiverAddress = value;
        }
        public string ReceiverPhone
        {
            get => receiverPhone;
            set => receiverPhone = value;
        }
        public Receiver(string receiverID ,string receiverName, string receiverAddress,
            string receiverPhone)
        {
            this.receiverID = receiverID;

            this.receiverAddress = receiverAddress;
            this.receiverName = receiverName;
            this.receiverPhone = receiverPhone;

        }
		 public override string ToString()
        {
            return receiverName + " " + receiverAddress + " " + receiverPhone;
        }

    }
}
