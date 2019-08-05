using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Models
{
    public class ProgressModel
    {
        private int _index = 0;
        private int _count = 0;

        public ProgressModel(int count)
        {
            this.Count = count;
        }

        public int Count
        {
            set
            {
                if (value < 0)
                    throw new Exception("Count 必须大于0");
                else
                {
                    _count = value;
                }
            }
            get { return _count; }
        }

        public int Index
        {
            set
            {
                if (value < 0)
                    throw new Exception("Index 必须大于0");
                else
                {
                    _index = value;
                }
            }
            get { return _index; }
        }

        public int CurrentPercent { get; set; }

        public int OriginalPercent { get; set; }



        public int GetPercent(int index)
        {
            this.Index = index;

            CurrentPercent = (int)Math.Floor(this.Index * 1.0 / Count * 100);

            OriginalPercent = (int)Math.Floor((this.Index - 1) * 1.0 / Count * 100);

            return CurrentPercent;
        }

        public bool IsChange
        {
            get
            {
                if (this.CurrentPercent > this.OriginalPercent)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
