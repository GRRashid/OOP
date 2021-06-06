namespace Backups
{
    class DateCleaner : ICleaner
    {
        private int date_;
        public DateCleaner(int date)
        {
            date_ = date;
        }

        public override bool IsCorrect(RecoveryPoint point)
        {
            return point.GetDate() > date_;
        }

        public override void Correct(RecoveryPoint point)
        {
            if (!IsCorrect(point))
            {
                point.ToFull();
            }
        }
    }
}
