
namespace Claw.Controls {
    public class SequenceCompletedEvent : GameEvent {

        private readonly string seqName;

        public string SeqName { get { return seqName; } }

        public SequenceCompletedEvent(string seqName) {
            this.seqName = seqName;
        }
    }
}