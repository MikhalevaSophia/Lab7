using System;

namespace lybrary
{
    internal class CommentAttribute : Attribute
    {
        public  string? Comment { get; }
        public CommentAttribute() { }
        public CommentAttribute(string comment) => Comment = comment;
    }
}
