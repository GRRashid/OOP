namespace Backups
{
    class MainCleaner : ICleaner
    {
        private ICleaner cleaner1;
        private ICleaner cleaner2;
        private int connection_;
        public MainCleaner(int connection = 0, ICleaner clean1 = null, ICleaner clean2 = null)
        {
            connection_ = connection;
            cleaner1 = clean1;
            cleaner2 = clean2;
        }

        public override bool IsCorrect(RecoveryPoint point)
        {
            if (cleaner1 != null && cleaner2 != null && connection_ == 1)
            {
                return cleaner1.IsCorrect(point) || cleaner2.IsCorrect(point);
            }
            else if (cleaner1 != null && cleaner2 != null)
            {
                return cleaner1.IsCorrect(point) && cleaner2.IsCorrect(point);
            }
            else if (cleaner1 != null)
            {
                return cleaner1.IsCorrect(point);
            }
            else if (cleaner2 != null)
            {
                return cleaner2.IsCorrect(point);
            }
            return true;
        }

        public override void Correct(RecoveryPoint point)
        {
            if (!IsCorrect(point))
            {
                if (cleaner1 != null)
                    cleaner1.Correct(point);
                if (cleaner2 != null)
                    cleaner2.Correct(point);
            }
        }
    }
}
