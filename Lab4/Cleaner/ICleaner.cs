namespace Backups
{
    class ICleaner
    {
        public ICleaner()
        { }

        public virtual bool IsCorrect(RecoveryPoint point) => true;
        public virtual void Correct(RecoveryPoint point) { }
    }
}
