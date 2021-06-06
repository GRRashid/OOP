namespace Backups
{
    class SizeCleaner : ICleaner
    {
        private int size_;
        public SizeCleaner(int size)
        {
            size_ = size;
        }

        public override bool IsCorrect(RecoveryPoint point)
        {
            int result = 0;
            foreach (var file in point.Files())
            {
                result += point.GetFile(file).size;
            }
            return result > size_;
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
