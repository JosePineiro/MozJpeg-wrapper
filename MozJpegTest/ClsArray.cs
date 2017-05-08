using System.Collections.Generic;

namespace ClsArray
{
    class clsArray
    {
        static readonly int[] Empty = new int[0];

        public static int[] Locate(ref byte[] self, byte[] candidate)
        {
            try
            {
                if (IsEmptyLocate(self, candidate))
                    return Empty;

                var list = new List<int>();

                for (int i = 0; i < self.Length; i++)
                {
                    if (!IsMatch(self, i, candidate))
                        continue;

                    list.Add(i);
                }

                return list.Count == 0 ? Empty : list.ToArray();
            }
            catch { throw; }
        }

        private static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            try
            {
                if (candidate.Length > (array.Length - position))
                    return false;

                for (int i = 0; i < candidate.Length; i++)
                    if (array[position + i] != candidate[i])
                        return false;

                return true;
            }
            catch { throw; }
        }

        private static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            try
            {
                return array == null
                    || candidate == null
                    || array.Length == 0
                    || candidate.Length == 0
                    || candidate.Length > array.Length;
            }
            catch { throw; }
        }
    }
}
