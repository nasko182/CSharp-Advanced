using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.FroggyNMS
{
    public class Lake : IEnumerable<int>
    {
        public Lake(List<int> stones)
        {
            Stones= stones;
        }
        public List<int> Stones { get; set; }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Count; i+=2)
            {
                yield return Stones[i];
            }
            if (Stones.Count%2==0)
            {
                for (int i = Stones.Count - 1; i >= 0; i-=2)
                {
                    yield return Stones[i];
                }
            }
            else
            {
                for (int i = Stones.Count - 2; i >= 0; i -= 2)
                {
                    yield return Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
