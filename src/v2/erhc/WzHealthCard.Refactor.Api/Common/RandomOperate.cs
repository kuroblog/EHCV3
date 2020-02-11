using System;
using System.Text;

namespace WzHealthCard.Refactor.Api.Common
{
    /// <summary>随机字符串生成器</summary>
    public class RandomOperate
    {
        /// <summary>字符</summary>
        private static readonly char[] keys = new char[35]
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'i',
            'J',
            'K',
            'L',
            'M',
            'N',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z'
        };
        /// <summary>基准数字</summary>
        private static readonly long BaseTicks = new DateTime(2015, 1, 1).Ticks;

        /// <summary>内部构架</summary>
        private RandomOperate()
        {
        }

        /// <summary>随机生成字符串（数字和字母混和）</summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string Generate(int codeCount)
        {
            return new RandomOperate().GenerateCode(codeCount);
        }

        private string GenerateCode(int codeCount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random1 = new Random((int)(DateTime.Now.Ticks - RandomOperate.BaseTicks));
            Random random2 = new Random(this.GetHashCode());
            for (int index = 0; index < codeCount; index += 2)
            {
                stringBuilder.Append(RandomOperate.keys[random1.Next(RandomOperate.keys.Length)]);
                stringBuilder.Append(RandomOperate.keys[random2.Next(RandomOperate.keys.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}