using HarmonyLib;
using SweetPotato;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace NSJ2
{
    public class Helpers
    {
        public static T GetPrivateField<T>(object instance, string fieldName)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException(nameof(fieldName));

            // Use AccessTools to get the field
            return AccessTools.FieldRefAccess<T>(instance.GetType(), fieldName)(instance);
        }
        public static void SetPrivateField<T>(object instance, string fieldName, T newValue)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException(nameof(fieldName));

            // Use AccessTools for efficiency
            var fieldRef = AccessTools.FieldRefAccess<T>(instance.GetType(), fieldName);
            fieldRef(instance) = newValue;
        }

        public static T GetPrivateProperty<T>(object instance, string propertyName)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var type = instance.GetType();

            // Try property first
            var prop = type.GetProperty(
                propertyName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (prop != null)
            {
                return (T)prop.GetValue(instance, null);
            }

            // Fallback: try getter method directly (get_PropertyName)
            var getter = type.GetMethod(
                "get_" + propertyName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (getter != null)
            {
                return (T)getter.Invoke(instance, null);
            }

            throw new MissingMemberException(type.FullName, propertyName);
        }

        public static void SetPrivateProperty<T>(object instance, string propertyName, T value)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var type = instance.GetType();

            var prop = type.GetProperty(
                propertyName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (prop != null)
            {
                prop.SetValue(instance, value, null);
                return;
            }

            var setter = type.GetMethod(
                "set_" + propertyName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (setter != null)
            {
                setter.Invoke(instance, new object[] { value });
                return;
            }

            throw new MissingMemberException(type.FullName, propertyName);
        }

        public static string GetRealCaller(int skipFrames = 1)
        {
            var stackTrace = new StackTrace(skipFrames, true);
            foreach (var frame in stackTrace.GetFrames())
            {
                MethodBase method = frame.GetMethod();
                if (method == null) continue;

                // Skip Harmony-generated dynamic methods
                if (method.Name.Contains("DMD<")) continue;

                // Skip helper class itself
                if (method.DeclaringType == typeof(Helpers)) continue;

                return $"{method.DeclaringType.FullName}.{method.Name}";
            }

            return "UnknownCaller";
        }

        /// <summary>
        /// Logs a traced call for debugging.
        /// </summary>
        public static void LogCaller(string message = "", int skipFrames = 1)
        {
            string caller = GetRealCaller(skipFrames + 1); // +1 for hero.battleDataBehaviour.battleData method
            Main.Log.LogInfo($"{message} Called by: {caller}");
        }

        public static void AddAllItems(ItemStorage __instance)
        {
            foreach(var kv in ItemPrototype.mTemplateList)
            {
                __instance.CreateAndAddByItemId(ItemPrototype.mTemplateList[kv.Key].itemId, 1);
            }
        }

        public static void AddAllMartialScrolls(ItemStorage __instance)
        {
            foreach (var kv in ItemPrototype.mTemplateList)
            {
                ItemPrototype item = kv.Value;
                if (item.type == 4 && item.subType == 15)
                {
                    ItemStorage_Original.CreateItem(__instance, item.itemId, 1);
                }            
            }
        }

        public static void SetMaxValues(AttriManager __instance)
        {
            for (int i = 12; i <= 19; i++)
            {
                AttriType attriType = (AttriType)(sbyte)i;
                __instance.SetAttriField(attriType, 1000, -1, -1, false);
                Main.Log.LogInfo($"Successfully set attribute: {attriType}, with ID: {i}");
            }

            for (int i = 34; i <= 41; i++)
            {
                AttriType attriType = (AttriType)(sbyte)i;
                __instance.SetAttriField(attriType, 1000, -1, -1, false);
                Main.Log.LogInfo($"Successfully set attribute: {attriType}, with ID: {i}");
            }

            for (int i = 42; i <= 49; i++)
            {
                AttriType attriType = (AttriType)(sbyte)i;
                __instance.SetAttriField(attriType, 1000, -1, -1, false);
                Main.Log.LogInfo($"Successfully set attribute: {attriType}, with ID: {i}");
            }

            for (int i = 50; i <= 65; i++)
            {
                AttriType attriType = (AttriType)(sbyte)i;
                __instance.SetAttriField(attriType, 1000, -1, -1, false);
                Main.Log.LogInfo($"Successfully set attribute: {attriType}, with ID: {i}");
            }

            for (int i = 4; i <= 11; i++)
            {
                //if (__instance.GetAttriResult((AttriType)i, true) < 20)
                {
                    AttriType attriType = (AttriType)(sbyte)i;
                    __instance.SetAttriField(attriType, 20, -1, -1, false);
                    Main.Log.LogInfo($"Successfully set attribute: {attriType}, with ID: {i}");
                }          
            }

            if (__instance.GetAttriResult(Attr.Comprehension, true) < 250)
            {
                __instance.SetAttriField(Attr.Comprehension, 250, -1, -1, false);
            }
            
        }

        public static readonly Dictionary<string, AttriType> AttrNameToType = new Dictionary<string, AttriType>
        {
            // Core
            { "Max HP", AttriType.HpMax },              // ID 1 -> 0
            { "True Qi", AttriType.MpMax },                // ID 2 -> 1     

            // Base stats
            { "Vitality", AttriType.YuanQi },              // ID 5 -> 4
            { "Potential", AttriType.GenGu },              // ID 6 -> 5
            { "Strength", AttriType.JinGu },               // ID 7 -> 6
            { "Inner Power", AttriType.NeiXi },             // ID 8 -> 7
            { "Resilience", AttriType.TiPo },              // ID 9 -> 8
            { "Willpower", AttriType.JingShen },            // ID 10 -> 9
            { "Agility", AttriType.ShenFa },                // ID 11 -> 10
            { "Focus", AttriType.ZhuanZhu },                // ID 12 -> 11
            { "Luck", AttriType.FuQi },                     // ID 13 -> 12
            { "Beauty", AttriType.RongMao },                // ID 14 -> 13
            { "Eloquence", AttriType.KouCai },              // ID 15 -> 14
            { "Commerce", AttriType.ShangDao },             // ID 16 -> 15
            { "Courage", AttriType.DanShi },                // ID 17 -> 16
            { "Cultivation", AttriType.XiuYang },           // ID 18 -> 17
            { "Toughness", AttriType.JianRen },             // ID 19 -> 18
            { "Generosity", AttriType.HaoShuang },          // ID 20 -> 19

            // Combat
            { "External Attack", AttriType.WaiAttack },    // ID 21 -> 20
            { "Internal Attack", AttriType.NeiAttack },    // ID 22 -> 21
            { "External Defense", AttriType.WaiDefence },  // ID 23 -> 22
            { "Internal Defense", AttriType.NeiDefence },  // ID 24 -> 23
            { "Mind Attack", AttriType.ZhuXin },           // ID 25 -> 24
            { "Discipline", AttriType.YuXin },             // ID 26 -> 25
            { "Vital Point", AttriType.YaoHai },           // ID 27 -> 26
            { "Counter", AttriType.HuaJie },               // ID 28 -> 27

            // Elements
            { "Yin", AttriType.Yin },                      // ID 29 -> 28
            { "Yang", AttriType.Yang },                    // ID 30 -> 29
            { "Hard", AttriType.Gang },                    // ID 31 -> 30
            { "Soft", AttriType.Rou },                     // ID 32 -> 31
            { "Poison", AttriType.Du },                    // ID 33 -> 32

            // Martial skills
            { "Blade", AttriType.DaoFa },               // ID 35 -> 34
            { "Swordsmanship", AttriType.JianShu },        // ID 36 -> 35
            { "Combat", AttriType.BoJi },                  // ID 37 -> 36
            { "Spear", AttriType.QiangGun },       // ID 38 -> 37
            { "Hidden Weapon", AttriType.Anqi },           // ID 39 -> 38
            { "Mystical Arts", AttriType.QiShu },          // ID 40 -> 39
            { "Healing Arts", AttriType.YiDao },           // ID 41 -> 40
            { "Poison Technique", AttriType.DuJi },        // ID 42 -> 41

            // Schools
            { "Taoism", AttriType.DaoXue },                 // ID 43 -> 42
            { "Buddhism", AttriType.FoXue },                // ID 44 -> 43
            { "Confucianism", AttriType.RuXue },           // ID 45 -> 44
            { "Martial Prowess", AttriType.BinXue },       // ID 46 -> 45
            { "Mohism", AttriType.MoXue },                 // ID 47 -> 46
            { "Deception", AttriType.GuiXue },             // ID 48 -> 47
            { "Dark Arts", AttriType.MoFaXue },            // ID 49 -> 48
            { "Agriculture", AttriType.NongXue },          // ID 50 -> 49

            // Life skills
            { "Alchemy", AttriType.LianDan },              // ID 51 -> 50
            { "Refining", AttriType.LianQi },              // ID 52 -> 51
            { "Skilled Hands", AttriType.QiaoShou },       // ID 53 -> 52
            { "Sewing", AttriType.FengRen },               // ID 54 -> 53
            { "Brewing", AttriType.NiangJiu },             // ID 55 -> 54
            { "Cooking", AttriType.PenRen },               // ID 56 -> 55
            { "Identifying Minerals", AttriType.BianKuang }, // ID 57 -> 56
            { "Farmer's Wisdom", AttriType.CaiYao },       // ID 58 -> 57
            { "Zither Art", AttriType.QinYi },             // ID 59 -> 58
            { "Chess Art", AttriType.QiYi },               // ID 60 -> 59
            { "Calligraphy", AttriType.ShuFa },            // ID 61 -> 60
            { "Painting", AttriType.HuaDao },              // ID 62 -> 61
            { "Alcohol Tolerance", AttriType.JiuLiang },   // ID 63 -> 62
            { "Fishing", AttriType.ChuiDiao },             // ID 64 -> 63
            { "Hunting", AttriType.DaLie },                // ID 65 -> 64
            { "Cultivation (Planting)", AttriType.ZhongZhi }, // ID 66 -> 65

            // Morality & misc
            { "Morality", AttriType.DaoDe },                // ID 68 -> 67

            // Combat derived
            { "Comprehension", AttriType.WuXing },          // ID 74 -> 73
            { "Hit Rate", AttriType.Hit },                  // ID 75 -> 74
            { "Dodge", AttriType.Dodge },                   // ID 76 -> 75
            { "Critical", AttriType.Critical },             // ID 77 -> 76

            // Energy & movement
            { "Energy", AttriType.JingliMax },              // ID 85 -> 84
            { "Qinggong", AttriType.QingGongPoint },        // ID 89 -> 88
            { "Maximum value of qinggong", AttriType.QingGongMax }, // ID 90 -> 89
        };
    }
}
