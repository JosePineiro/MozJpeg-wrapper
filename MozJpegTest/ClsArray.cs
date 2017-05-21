using System;
using System.Collections.Generic;

namespace ClsArray
{
    class clsArray
    {
        static readonly int[] Empty = new int[0];

        public static List<int> Locate(ref byte[] self, byte[] candidate)
        {
            try
            {
                List<int> list = new List<int>();

                if (IsEmptyLocate(self, candidate))
                    return list;

                for (int i = 0; i < self.Length; i++)
                {
                    if (!IsMatch(self, i, candidate))
                        continue;

                    list.Add(i);
                }

                //return list.Count == 0 ? Empty : list.ToArray();
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + "\r\nIn clsArray.Locate"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + "\r\nIn clsArray.IsMatch"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + "\r\nIn clsArray.IsEmptyLocate"); }
        }
    }
}
