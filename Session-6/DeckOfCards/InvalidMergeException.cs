using System;


namespace DeckOfCards
{
    internal class InvalidMergeException:Exception
    {
        public InvalidMergeException() { }

        public Type MergeWith { get; set; }

        public Type ToMerge { get; set; }

        public InvalidMergeException(string message,Type toMerge,Type mergeWith) : base(message)
        {
            this.MergeWith=mergeWith; 
            this.ToMerge=toMerge;
        }
    }
}
