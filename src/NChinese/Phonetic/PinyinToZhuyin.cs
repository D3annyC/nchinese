﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NChinese.Phonetic;

public static class PinyinToZhuyin
{
    private const string ZhuyinTones = "˙\x02c9ˊˇˋ";
    private static Dictionary<string, string> _pinyinToZhuyinTable;
    private static Dictionary<char, string> _pinyinToneTable;


    static PinyinToZhuyin()
    {
        _pinyinToZhuyinTable = new Dictionary<string, string>
        {
            { "a",      "ㄚ" },
            { "ai",     "ㄞ" },
            { "an",     "ㄢ" },
            { "ang",    "ㄤ" },
            { "ao",     "ㄠ" },
            { "ba",     "ㄅㄚ" },
            { "bai",    "ㄅㄞ" },
            { "ban",    "ㄅㄢ" },
            { "bang",   "ㄅㄤ" },
            { "bao",    "ㄅㄠ" },
            { "bei",    "ㄅㄟ" },
            { "ben",    "ㄅㄣ" },
            { "beng",   "ㄅㄥ" },
            { "bi",     "ㄅㄧ" },
            { "bian",   "ㄅㄧㄢ" },
            { "biao",   "ㄅㄧㄠ" },
            { "bie",    "ㄅㄧㄝ" },
            { "bin",    "ㄅㄧㄣ" },
            { "bing",   "ㄅㄧㄥ" },
            { "bo",     "ㄅㄛ" },
            { "bu",     "ㄅㄨ" },
            { "ca",     "ㄘㄚ" },
            { "cai",    "ㄘㄞ" },
            { "can",    "ㄘㄢ" },
            { "cang",   "ㄘㄤ" },
            { "cao",    "ㄘㄠ" },
            { "ce",     "ㄘㄜ" },
            { "cen",    "ㄘㄣ" },
            { "ceng",   "ㄘㄥ" },
            { "cha",    "ㄔㄚ" },
            { "chai",   "ㄔㄞ" },
            { "chan",   "ㄔㄢ" },
            { "chang",  "ㄔㄤ" },
            { "chao",   "ㄔㄠ" },
            { "che",    "ㄔㄜ" },
            { "chen",   "ㄔㄣ" },
            { "cheng",  "ㄔㄥ" },
            { "chi",    "ㄔ" },
            { "chong",  "ㄔㄨㄥ" },
            { "chou",   "ㄔㄡ" },
            { "chu",    "ㄔㄨ" },
            { "chua",   "ㄔㄨㄚ" },
            { "chuai",  "ㄔㄨㄞ" },
            { "chuan",  "ㄔㄨㄢ" },
            { "chuang", "ㄔㄨㄤ" },
            { "chui",   "ㄔㄨㄟ" },
            { "chun",   "ㄔㄨㄣ" },
            { "chuo",   "ㄔㄨㄛ" },
            { "ci",     "ㄘ" },
            { "cong",   "ㄘㄨㄥ" },
            { "cou",    "ㄘㄡ" },
            { "cu",     "ㄘㄨ" },
            { "cuan",   "ㄘㄨㄢ" },
            { "cui",    "ㄘㄨㄟ" },
            { "cun",    "ㄘㄨㄣ" },
            { "cuo",    "ㄘㄨㄛ" },
            { "da",     "ㄉㄚ" },
            { "dai",    "ㄉㄞ" },
            { "dan",    "ㄉㄢ" },
            { "dang",   "ㄉㄤ" },
            { "dao",    "ㄉㄠ" },
            { "de",     "ㄉㄜ" },
            { "dei",    "ㄉㄟ" },
            { "den",    "ㄉㄣ" },
            { "deng",   "ㄉㄥ" },
            { "di",     "ㄉㄧ" },
            { "dia",    "ㄉㄧㄚ" },
            { "dian",   "ㄉㄧㄢ" },
            { "diao",   "ㄉㄧㄠ" },
            { "die",    "ㄉㄧㄝ" },
            { "ding",   "ㄉㄧㄥ" },
            { "diu",    "ㄉㄧㄡ" },
            { "dong",   "ㄉㄨㄥ" },
            { "dou",    "ㄉㄡ" },
            { "du",     "ㄉㄨ" },
            { "duan",   "ㄉㄨㄢ" },
            { "dui",    "ㄉㄨㄟ" },
            { "dun",    "ㄉㄨㄣ" },
            { "duo",    "ㄉㄨㄛ" },
            { "e",      "ㄜ" },
            { "ei",     "ㄟ" },
            { "en",     "ㄣ" },
            { "eng",    "ㄥ" },
            { "er",     "ㄦ" },
            { "fa",     "ㄈㄚ" },
            { "fan",    "ㄈㄢ" },
            { "fang",   "ㄈㄤ" },
            { "fei",    "ㄈㄟ" },
            { "fen",    "ㄈㄣ" },
            { "feng",   "ㄈㄥ" },
            { "fo",     "ㄈㄛ" },
            { "fou",    "ㄈㄡ" },
            { "fu",     "ㄈㄨ" },
            { "ga",     "ㄍㄚ" },
            { "gai",    "ㄍㄞ" },
            { "gan",    "ㄍㄢ" },
            { "gang",   "ㄍㄤ" },
            { "gao",    "ㄍㄠ" },
            { "ge",     "ㄍㄜ" },
            { "gei",    "ㄍㄟ" },
            { "gen",    "ㄍㄣ" },
            { "geng",   "ㄍㄥ" },
            { "gong",   "ㄍㄨㄥ" },
            { "gou",    "ㄍㄡ" },
            { "gu",     "ㄍㄨ" },
            { "gua",    "ㄍㄨㄚ" },
            { "guai",   "ㄍㄨㄞ" },
            { "guan",   "ㄍㄨㄢ" },
            { "guang",  "ㄍㄨㄤ" },
            { "gui",    "ㄍㄨㄟ" },
            { "gun",    "ㄍㄨㄣ" },
            { "guo",    "ㄍㄨㄛ" },
            { "ha",     "ㄏㄚ" },
            { "hai",    "ㄏㄞ" },
            { "han",    "ㄏㄢ" },
            { "hang",   "ㄏㄤ" },
            { "hao",    "ㄏㄠ" },
            { "he",     "ㄏㄜ" },
            { "hei",    "ㄏㄟ" },
            { "hen",    "ㄏㄣ" },
            { "heng",   "ㄏㄥ" },
            { "hong",   "ㄏㄨㄥ" },
            { "hou",    "ㄏㄡ" },
            { "hu",     "ㄏㄨ" },
            { "hua",    "ㄏㄨㄚ" },
            { "huai",   "ㄏㄨㄞ" },
            { "huan",   "ㄏㄨㄢ" },
            { "huang",  "ㄏㄨㄤ" },
            { "hui",    "ㄏㄨㄟ" },
            { "hun",    "ㄏㄨㄣ" },
            { "huo",    "ㄏㄨㄛ" },
            { "ji",     "ㄐㄧ" },
            { "jia",    "ㄐㄧㄚ" },
            { "jian",   "ㄐㄧㄢ" },
            { "jiang",  "ㄐㄧㄤ" },
            { "jiao",   "ㄐㄧㄠ" },
            { "jie",    "ㄐㄧㄝ" },
            { "jin",    "ㄐㄧㄣ" },
            { "jing",   "ㄐㄧㄥ" },
            { "jiong",  "ㄐㄩㄥ" },
            { "jiu",    "ㄐㄧㄡ" },
            { "ju",     "ㄐㄩ" },
            { "juan",   "ㄐㄩㄢ" },
            { "jue",    "ㄐㄩㄝ" },
            { "jun",    "ㄐㄩㄣ" },
            { "ka",     "ㄎㄚ" },
            { "kai",    "ㄎㄞ" },
            { "kan",    "ㄎㄢ" },
            { "kang",   "ㄎㄤ" },
            { "kao",    "ㄎㄠ" },
            { "ke",     "ㄎㄜ" },
            { "kei",    "ㄎㄟ" },
            { "ken",    "ㄎㄣ" },
            { "keng",   "ㄎㄥ" },
            { "kong",   "ㄎㄨㄥ" },
            { "kou",    "ㄎㄡ" },
            { "ku",     "ㄎㄨ" },
            { "kua",    "ㄎㄨㄚ" },
            { "kuai",   "ㄎㄨㄞ" },
            { "kuan",   "ㄎㄨㄢ" },
            { "kuang",  "ㄎㄨㄤ" },
            { "kui",    "ㄎㄨㄟ" },
            { "kun",    "ㄎㄨㄣ" },
            { "kuo",    "ㄎㄨㄛ" },
            { "la",     "ㄌㄚ" },
            { "lai",    "ㄌㄞ" },
            { "lan",    "ㄌㄢ" },
            { "lang",   "ㄌㄤ" },
            { "lao",    "ㄌㄠ" },
            { "le",     "ㄌㄜ" },
            { "lei",    "ㄌㄟ" },
            { "leng",   "ㄌㄥ" },
            { "li",     "ㄌㄧ" },
            { "lia",    "ㄌㄧㄚ" },
            { "lian",   "ㄌㄧㄢ" },
            { "liang",  "ㄌㄧㄤ" },
            { "liao",   "ㄌㄧㄠ" },
            { "lie",    "ㄌㄧㄝ" },
            { "lin",    "ㄌㄧㄣ" },
            { "ling",   "ㄌㄧㄥ" },
            { "liu",    "ㄌㄧㄡ" },
            { "long",   "ㄌㄨㄥ" },
            { "lou",    "ㄌㄡ" },
            { "lu",     "ㄌㄨ" },
            { "lv",     "ㄌㄩ" },
            { "luan",   "ㄌㄨㄢ" },
            { "lve",    "ㄌㄩㄝ" },
            { "lun",    "ㄌㄨㄣ" },
            { "luo",    "ㄌㄨㄛ" },
            { "ma",     "ㄇㄚ" },
            { "mai",    "ㄇㄞ" },
            { "man",    "ㄇㄢ" },
            { "mang",   "ㄇㄤ" },
            { "mao",    "ㄇㄠ" },
            { "me",     "ㄇㄜ" },
            { "mei",    "ㄇㄟ" },
            { "men",    "ㄇㄣ" },
            { "meng",   "ㄇㄥ" },
            { "mi",     "ㄇㄧ" },
            { "mian",   "ㄇㄧㄢ" },
            { "miao",   "ㄇㄧㄠ" },
            { "mie",    "ㄇㄧㄝ" },
            { "min",    "ㄇㄧㄣ" },
            { "ming",   "ㄇㄧㄥ" },
            { "miu",    "ㄇㄧㄡ" },
            { "mo",     "ㄇㄛ" },
            { "mou",    "ㄇㄡ" },
            { "mu",     "ㄇㄨ" },
            { "na",     "ㄋㄚ" },
            { "nai",    "ㄋㄞ" },
            { "nan",    "ㄋㄢ" },
            { "nang",   "ㄋㄤ" },
            { "nao",    "ㄋㄠ" },
            { "ne",     "ㄋㄜ" },
            { "nei",    "ㄋㄟ" },
            { "nen",    "ㄋㄣ" },
            { "neng",   "ㄋㄥ" },
            { "ni",     "ㄋㄧ" },
            { "nian",   "ㄋㄧㄢ" },
            { "niang",  "ㄋㄧㄤ" },
            { "niao",   "ㄋㄧㄠ" },
            { "nie",    "ㄋㄧㄝ" },
            { "nin",    "ㄋㄧㄣ" },
            { "ning",   "ㄋㄧㄥ" },
            { "niu",    "ㄋㄧㄡ" },
            { "nong",   "ㄋㄨㄥ" },
            { "nou",    "ㄋㄡ" },
            { "nu",     "ㄋㄨ" },
            { "nv",     "ㄋㄩ" },
            { "nuan",   "ㄋㄨㄢ" },
            { "nve",    "ㄋㄩㄝ" },
            { "nun",    "ㄋㄨㄣ" },
            { "nuo",    "ㄋㄨㄛ" },
            { "o",      "ㄛ" },
            { "ou",     "ㄡ" },
            { "pa",     "ㄆㄚ" },
            { "pai",    "ㄆㄞ" },
            { "pan",    "ㄆㄢ" },
            { "pang",   "ㄆㄤ" },
            { "pao",    "ㄆㄠ" },
            { "pei",    "ㄆㄟ" },
            { "pen",    "ㄆㄣ" },
            { "peng",   "ㄆㄥ" },
            { "pi",     "ㄆㄧ" },
            { "pian",   "ㄆㄧㄢ" },
            { "piao",   "ㄆㄧㄠ" },
            { "pie",    "ㄆㄧㄝ" },
            { "pin",    "ㄆㄧㄣ" },
            { "ping",   "ㄆㄧㄥ" },
            { "po",     "ㄆㄛ" },
            { "pou",    "ㄆㄡ" },
            { "pu",     "ㄆㄨ" },
            { "qi",     "ㄑㄧ" },
            { "qia",    "ㄑㄧㄚ" },
            { "qian",   "ㄑㄧㄢ" },
            { "qiang",  "ㄑㄧㄤ" },
            { "qiao",   "ㄑㄧㄠ" },
            { "qie",    "ㄑㄧㄝ" },
            { "qin",    "ㄑㄧㄣ" },
            { "qing",   "ㄑㄧㄥ" },
            { "qiong",  "ㄑㄩㄥ" },
            { "qiu",    "ㄑㄧㄡ" },
            { "qu",     "ㄑㄩ" },
            { "quan",   "ㄑㄩㄢ" },
            { "que",    "ㄑㄩㄝ" },
            { "qun",    "ㄑㄩㄣ" },
            { "ran",    "ㄖㄢ" },
            { "rang",   "ㄖㄤ" },
            { "rao",    "ㄖㄠ" },
            { "re",     "ㄖㄜ" },
            { "ren",    "ㄖㄣ" },
            { "reng",   "ㄖㄥ" },
            { "ri",     "ㄖ" },
            { "rong",   "ㄖㄨㄥ" },
            { "rou",    "ㄖㄡ" },
            { "ru",     "ㄖㄨ" },
            { "rua",    "ㄖㄨㄚ" },
            { "ruan",   "ㄖㄨㄢ" },
            { "rui",    "ㄖㄨㄟ" },
            { "run",    "ㄖㄨㄣ" },
            { "ruo",    "ㄖㄨㄛ" },
            { "sa",     "ㄙㄚ" },
            { "sai",    "ㄙㄞ" },
            { "san",    "ㄙㄢ" },
            { "sang",   "ㄙㄤ" },
            { "sao",    "ㄙㄠ" },
            { "se",     "ㄙㄜ" },
            { "sen",    "ㄙㄣ" },
            { "seng",   "ㄙㄥ" },
            { "sha",    "ㄕㄚ" },
            { "shai",   "ㄕㄞ" },
            { "shan",   "ㄕㄢ" },
            { "shang",  "ㄕㄤ" },
            { "shao",   "ㄕㄠ" },
            { "she",    "ㄕㄜ" },
            { "shei",   "ㄕㄟ" },
            { "shen",   "ㄕㄣ" },
            { "sheng",  "ㄕㄥ" },
            { "shi",    "ㄕ" },
            { "shou",   "ㄕㄡ" },
            { "shu",    "ㄕㄨ" },
            { "shua",   "ㄕㄨㄚ" },
            { "shuai",  "ㄕㄨㄞ" },
            { "shuan",  "ㄕㄨㄢ" },
            { "shuang", "ㄕㄨㄤ" },
            { "shui",   "ㄕㄨㄟ" },
            { "shun",   "ㄕㄨㄣ" },
            { "shuo",   "ㄕㄨㄛ" },
            { "si",     "ㄙ" },
            { "song",   "ㄙㄨㄥ" },
            { "sou",    "ㄙㄡ" },
            { "su",     "ㄙㄨ" },
            { "suan",   "ㄙㄨㄢ" },
            { "sui",    "ㄙㄨㄟ" },
            { "sun",    "ㄙㄨㄣ" },
            { "suo",    "ㄙㄨㄛ" },
            { "ta",     "ㄊㄚ" },
            { "tai",    "ㄊㄞ" },
            { "tan",    "ㄊㄢ" },
            { "tang",   "ㄊㄤ" },
            { "tao",    "ㄊㄠ" },
            { "te",     "ㄊㄜ" },
            { "tei",    "ㄊㄟ" },
            { "teng",   "ㄊㄥ" },
            { "ti",     "ㄊㄧ" },
            { "tian",   "ㄊㄧㄢ" },
            { "tiao",   "ㄊㄧㄠ" },
            { "tie",    "ㄊㄧㄝ" },
            { "ting",   "ㄊㄧㄥ" },
            { "tong",   "ㄊㄨㄥ" },
            { "tou",    "ㄊㄡ" },
            { "tu",     "ㄊㄨ" },
            { "tuan",   "ㄊㄨㄢ" },
            { "tui",    "ㄊㄨㄟ" },
            { "tun",    "ㄊㄨㄣ" },
            { "tuo",    "ㄊㄨㄛ" },
            { "wa",     "ㄨㄚ" },
            { "wai",    "ㄨㄞ" },
            { "wan",    "ㄨㄢ" },
            { "wang",   "ㄨㄤ" },
            { "wei",    "ㄨㄟ" },
            { "wen",    "ㄨㄣ" },
            { "weng",   "ㄨㄥ" },
            { "wo",     "ㄨㄛ" },
            { "wu",     "ㄨ" },
            { "xi",     "ㄒㄧ" },
            { "xia",    "ㄒㄧㄚ" },
            { "xian",   "ㄒㄧㄢ" },
            { "xiang",  "ㄒㄧㄤ" },
            { "xiao",   "ㄒㄧㄠ" },
            { "xie",    "ㄒㄧㄝ" },
            { "xin",    "ㄒㄧㄣ" },
            { "xing",   "ㄒㄧㄥ" },
            { "xiong",  "ㄒㄩㄥ" },
            { "xiu",    "ㄒㄧㄡ" },
            { "xu",     "ㄒㄩ" },
            { "xuan",   "ㄒㄩㄢ" },
            { "xue",    "ㄒㄩㄝ" },
            { "xun",    "ㄒㄩㄣ" },
            { "ya",     "ㄧㄚ" },
            { "yan",    "ㄧㄢ" },
            { "yang",   "ㄧㄤ" },
            { "yao",    "ㄧㄠ" },
            { "ye",     "ㄧㄝ" },
            { "yi",     "ㄧ" },
            { "yin",    "ㄧㄣ" },
            { "ying",   "ㄧㄥ" },
            { "yong",   "ㄩㄥ" },
            { "you",    "ㄧㄡ" },
            { "yu",     "ㄩ" },
            { "yuan",   "ㄩㄢ" },
            { "yue",    "ㄩㄝ" },
            { "yun",    "ㄩㄣ" },
            { "za",     "ㄗㄚ" },
            { "zai",    "ㄗㄞ" },
            { "zan",    "ㄗㄢ" },
            { "zang",   "ㄗㄤ" },
            { "zao",    "ㄗㄠ" },
            { "ze",     "ㄗㄜ" },
            { "zei",    "ㄗㄟ" },
            { "zen",    "ㄗㄣ" },
            { "zeng",   "ㄗㄥ" },
            { "zha",    "ㄓㄚ" },
            { "zhai",   "ㄓㄞ" },
            { "zhan",   "ㄓㄢ" },
            { "zhang",  "ㄓㄤ" },
            { "zhao",   "ㄓㄠ" },
            { "zhe",    "ㄓㄜ" },
            { "zhei",   "ㄓㄟ" },
            { "zhen",   "ㄓㄣ" },
            { "zheng",  "ㄓㄥ" },
            { "zhi",    "ㄓ" },
            { "zhong",  "ㄓㄨㄥ" },
            { "zhou",   "ㄓㄡ" },
            { "zhu",    "ㄓㄨ" },
            { "zhua",   "ㄓㄨㄚ" },
            { "zhuai",  "ㄓㄨㄞ" },
            { "zhuan",  "ㄓㄨㄢ" },
            { "zhuang", "ㄓㄨㄤ" },
            { "zhui",   "ㄓㄨㄟ" },
            { "zhun",   "ㄓㄨㄣ" },
            { "zhuo",   "ㄓㄨㄛ" },
            { "zi",     "ㄗ" },
            { "zong",   "ㄗㄨㄥ" },
            { "zou",    "ㄗㄡ" },
            { "zu",     "ㄗㄨ" },
            { "zuan",   "ㄗㄨㄢ" },
            { "zui",    "ㄗㄨㄟ" },
            { "zun",    "ㄗㄨㄣ" },
            { "zuo",    "ㄗㄨㄛ" }
        };

        _pinyinToneTable = new Dictionary<char, string>
        {
            { 'ā', "a1" },
            { 'á', "a2" },
            { 'ǎ', "a3" },
            { 'à', "a4" },
            { 'ē', "e1" },
            { 'é', "e2" },
            { 'ě', "e3" },
            { 'è', "e4" },
            { 'ō', "o1" },
            { 'ó', "o2" },
            { 'ǒ', "o3" },
            { 'ò', "o4" },
            { 'ī', "i1" },
            { 'í', "i2" },
            { 'ǐ', "i3" },
            { 'ì', "i4" },
            { 'ū', "u1" },
            { 'ú', "u2" },
            { 'ǔ', "u3" },
            { 'ù', "u4" },
            { 'ü', "v1" },
            { 'ǘ', "v2" },
            { 'ǚ', "v3" },
            { 'ǜ', "v4" },
            { 'ń', "n2" },
            { 'ň', "n3" },
            { '', "m2" }  // May be not used.
        };
    }


    public static string Convert(string pinyinStr)
    {
        var input = new StringBuilder(pinyinStr);

        // 找聲調符號
        int toneIndex = 0; // 預設為輕聲。若音調查閱表裡沒找到，則表示為輕聲。
        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];
            if (_pinyinToneTable.ContainsKey(current))
            {
                string tone = _pinyinToneTable[current];
                input[i] = tone[0]; // 找到聲調符號以後，把輸入字串中的拼音符號改成沒有音調註記的字元。
                toneIndex = System.Convert.ToInt32(tone[1].ToString());
                break;
            }
        }

        string pinyin = input.ToString();
        if (_pinyinToZhuyinTable.ContainsKey(pinyin) == false)
        {
            throw new Exception($"轉換失敗! 無此拼音組合：{pinyin}");
        }
        
        string zhuyin = _pinyinToZhuyinTable[pinyin];
        return zhuyin + ZhuyinTones[toneIndex];
    }
}
