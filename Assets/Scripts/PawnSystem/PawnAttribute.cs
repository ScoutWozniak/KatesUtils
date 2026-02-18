using System;

namespace PawnSystem
{
    /// <summary>
    /// Attach to classes that define a pawn
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PawnAttribute : Attribute
    {
        public string prefabPath;
        
        public PawnAttribute(string path)
        {
            prefabPath = path;
        }
    }
}