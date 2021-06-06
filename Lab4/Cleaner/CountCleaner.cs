namespace Backups
{
    class CountCleaner : ICleaner
    {
        private int count_;
        public CountCleaner(int count)
        {
            count_ = count;
        }

        public override bool IsCorrect(RecoveryPoint point)
        {
            RecoveryPoint p = point;
            int i = 0;
            while (p != null)
            {
                i++;
                p = p.GetDepend();
                if (i >= count_)
                    return false;
            }
            return true;
        }

        public override void Correct(RecoveryPoint point)
        {
            RecoveryPoint p = point;
            int i = 0;
            while (p != null)
            {
                i++;
                if (i >= count_)
                {
                    p.ToFull();
                }
                p = p.GetDepend();
            }
        }
    }
}
