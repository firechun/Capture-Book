using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 网上抓书
{
    class Article:IComparable<Article>
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Index { get; set; }
        public bool Success { get; set; }

        public int CompareTo(Article other)
        {
            return Index - other.Index;
        }
    }

    class ImageToText
    {
        public static Dictionary<string, string> Words = new Dictionary<string, string>
        {
            {"luan.jpg","乱" },
            {"pi.jpg","屁" } ,
            {"yao.jpg","腰" },
            {"man.jpg","满" },
            {"xing.jpg","性" },
            {"ru.jpg","乳" },
            {"you.jpg","诱" },
            {"tun2.jpg","臀" },
            {"rou.jpg","肉" },
            {"lang.jpg","浪" },
            {"yu.jpg","欲" },
            {"chun2.jpg" ,"唇" },
            {"shi.jpg","湿" },
            {"dang.jpg","荡" },
            {"nai.jpg","奶" },
            {"lou.jpg","露" },
            {"sai.jpg","塞" },
            {"ting.jpg","挺" },
            {"jiao.jpg","交" },
            {"mi2.jpg","迷" },
            {"qi2.jpg","妻" },
            {"ya.jpg","压" },
            {"ji.jpg","激" },
            {"nen.jpg","嫩" },
            {"ai.jpg","爱" },
            {"qiang.jpg","枪" },
            {"nong.jpg","弄" },
            {"can.jpg","缠" },
            {"ri.jpg","日" },
            {"chuang.jpg","床" },
            {"zhang.jpg","胀" },
            {"xi.jpg","吸" },
            {"xiong.jpg","胸" },
            {"ku.jpg","裤" },
            {"shu.jpg","熟" },
            {"yin3.jpg","吟" },
            {"min.jpg","敏" },
            {"jin.jpg","禁" },
            {"rou2.jpg","揉" },
            {"ji2.jpg","鸡" },
            {"bang.jpg","棒" },
            {"sao.jpg","骚" },
            {"xie.jpg","泄" },
            {"se.jpg","色" },
            {"shuang.jpg","爽" },
            {"cuo.jpg","搓" },
            {"chan.jpg","缠" },
            {"shun.jpg","吮" },
            {"liu.jpg","流" },
            {"yin.jpg","阴" },
            {"mao.jpg","毛" },
            {"feng.jpg","缝" },
            {"gan.jpg","感" },
            {"cu.jpg","粗" },
            {"huan.jpg","欢" },
            {"lu.jpg" ,"撸"  },
            {"gui.jpg","龟" },
            {"cao.jpg","操" },
            {"bi.jpg","逼" },
            {"cha.jpg","插" },
            {"ying.jpg","迎" },
            {"chuan.jpg","喘" },
            {"kua.jpg","胯" },
            {"ye.jpg","液" },
            {"chou.jpg","抽" },
            {"jing.jpg","精" },
            {"gen.jpg","更" },
            {"tian.jpg","舔" },
            {"dong.jpg","洞" },
            {"niao.jpg","尿" },
            {"xue.jpg","穴" },
            {"yang2.jpg","痒" },
            {"mi.jpg","蜜" },
            {"ru2.jpg","蠕" },
            {"she.jpg","射" },
            {"gong.jpg","宫" },
            {"yin2.jpg","淫" },
            {"tun.jpg","吞" },
            {"chao.jpg","潮" },
            {"tuo.jpg","脱" },
            {"bao.jpg","饱" },
            {"bi2.jpg","屄" },
            {"yan.jpg","艳" },
            {"luo.jpg","祼" },
            {"cao2.jpg","肏" },
            {"pen.jpg","喷" },
            {"chun.jpg","春" },
            {"yang.jpg","阳" },
            {"chi.jpg","耻" },
            {"jian.jpg","贱" },
            {"gun.jpg","棍" },
            {"bo.jpg","勃" },
            {"nue.jpg","虐" },
            {"gang.jpg","肛" },
            {"gao2.jpg","睾" },
            {"jian2.jpg","奸" },
            {"xie2.jpg","邪" },
            {"ji3.jpg","妓" },
            {"fu.jpg","阜" },
            {"dang2.jpg","党" },
            {"yi.jpg","绮" },
            {"liao.jpg","撩" },
            {"wei.jpg","慰" },
            {"diao.jpg","屌" },
            {"dong2.jpg","胴" },
            {"rui.jpg","蕊" },
        };
    }
}
