using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetPotato;

namespace NSJ2
{
    public static class Attr
    {
        // Core
        public static AttriType Lifeforce => AttriType.HpMax;
        public static AttriType TrueQi => AttriType.MpMax;
        public static AttriType Vitality => AttriType.YuanQi;

        // Body
        public static AttriType Potential => AttriType.GenGu;
        public static AttriType Strength => AttriType.JinGu;
        public static AttriType InnerPower => AttriType.NeiXi;
        public static AttriType Resilience => AttriType.TiPo;
        public static AttriType Willpower => AttriType.JingShen;
        public static AttriType Agility => AttriType.ShenFa;
        public static AttriType Focus => AttriType.ZhuanZhu;
        public static AttriType Luck => AttriType.FuQi;
        public static AttriType Beauty => AttriType.RongMao;
        public static AttriType Eloquence => AttriType.KouCai;
        public static AttriType Commerce => AttriType.ShangDao;
        public static AttriType Courage => AttriType.DanShi;
        public static AttriType Cultivation => AttriType.XiuYang;
        public static AttriType Toughness => AttriType.JianRen;
        public static AttriType Generosity => AttriType.HaoShuang;

        // Combat
        public static AttriType ExternalAttack => AttriType.WaiAttack;
        public static AttriType InternalAttack => AttriType.NeiAttack;
        public static AttriType ExternalDefense => AttriType.WaiDefence;
        public static AttriType InternalDefense => AttriType.NeiDefence;
        public static AttriType MindAttack => AttriType.ZhuXin;
        public static AttriType Discipline => AttriType.YuXin;
        public static AttriType VitalPoint => AttriType.YaoHai;
        public static AttriType Counter => AttriType.HuaJie;

        // Elements
        public static AttriType Yin => AttriType.Yin;
        public static AttriType Yang => AttriType.Yang;
        public static AttriType Hard => AttriType.Gang;
        public static AttriType Soft => AttriType.Rou;
        public static AttriType Poison => AttriType.Du;

        // Weapon skills
        public static AttriType BladeArt => AttriType.DaoFa;
        public static AttriType Swordsmanship => AttriType.JianShu;
        public static AttriType Combat => AttriType.BoJi;
        public static AttriType SpearStaff => AttriType.QiangGun;
        public static AttriType HiddenWeapon => AttriType.Anqi;
        public static AttriType MysticalArts => AttriType.QiShu;
        public static AttriType HealingArts => AttriType.YiDao;
        public static AttriType PoisonTechnique => AttriType.DuJi;

        // Knowledge
        public static AttriType Taoism => AttriType.DaoXue;
        public static AttriType Buddhism => AttriType.FoXue;
        public static AttriType Confucianism => AttriType.RuXue;
        public static AttriType MartialProwess => AttriType.BinXue;
        public static AttriType Mohism => AttriType.MoXue;
        public static AttriType Deception => AttriType.GuiXue;
        public static AttriType DarkArts => AttriType.MoFaXue;
        public static AttriType Agriculture => AttriType.NongXue;

        // Life skills
        public static AttriType Alchemy => AttriType.LianDan;
        public static AttriType Refining => AttriType.LianQi;
        public static AttriType SkilledHands => AttriType.QiaoShou;
        public static AttriType Sewing => AttriType.FengRen;
        public static AttriType Brewing => AttriType.NiangJiu;
        public static AttriType Cooking => AttriType.PenRen;
        public static AttriType IdentifyingMinerals => AttriType.BianKuang;
        public static AttriType Herbalism => AttriType.CaiYao;
        public static AttriType Zither => AttriType.QinYi;
        public static AttriType Chess => AttriType.QiYi;
        public static AttriType Calligraphy => AttriType.ShuFa;
        public static AttriType Painting => AttriType.HuaDao;
        public static AttriType AlcoholTolerance => AttriType.JiuLiang;
        public static AttriType Fishing => AttriType.ChuiDiao;
        public static AttriType Hunting => AttriType.DaLie;
        public static AttriType Farming => AttriType.ZhongZhi;

        // Misc
        public static AttriType Morality => AttriType.DaoDe;
        public static AttriType Comprehension => AttriType.WuXing;
        public static AttriType HitRate => AttriType.Hit;
        public static AttriType Dodge => AttriType.Dodge;
        public static AttriType Critical => AttriType.Critical;
        public static AttriType Energy => AttriType.JingliMax;
        public static AttriType Qinggong => AttriType.QingGongPoint;
        public static AttriType QinggongMax => AttriType.QingGongMax;
    }

}
