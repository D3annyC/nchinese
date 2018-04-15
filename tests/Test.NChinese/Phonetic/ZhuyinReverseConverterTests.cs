﻿using NChinese.Phonetic;
using NUnit.Framework;

namespace Test.NChinese.Phonetic
{
    [TestFixture]
    public class ZhuyinReverseConverterTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Should_CustomPhrase_Work()
        {
            // 手動加一個片語，以便觀察是否查詢字根時是否有用到片語資料。
            ZhuyinPhraseTable.GetInstance().AddPhrase("什麼 ㄕㄣˊ ㄇㄚˇ");

            var converter = new ZhuyinReverseConverter(new ZhuyinReverseConversionProvider());

            string aChineseText = "什麼";
            string[] expected = { "ㄕ　ㄣˊ", "ㄇ　ㄚˇ" };
            string[] actual = converter.GetZhuyinWithPhraseTable(aChineseText);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
