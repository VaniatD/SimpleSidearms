﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace SimpleSidearms
{
    public static class SkillStatMap
    {
        public static Dictionary<SkillDef, List<StatDef>> map;
        public static Dictionary<SkillDef, List<StatDef>> Map
        {
            get
            {
                if (map == null)
                    BuildMap();
                return map;
            }
        }
        public static void BuildMap()
        {
            map = new Dictionary<SkillDef, List<StatDef>>();

            foreach (SkillDef skill in DefDatabase<SkillDef>.AllDefsListForReading)
            {
                map[skill] = new List<StatDef>();
            }
            foreach (StatDef stat in DefDatabase<StatDef>.AllDefsListForReading)
            {
                if (stat.skillNeedFactors == null)
                {
                    continue;
                }
                foreach (SkillNeed neededSkill in stat.skillNeedFactors)
                {
                    if (!map[neededSkill.skill].Contains(stat))
                        map[neededSkill.skill].Add(stat);
                }
            }
        }
    }
}
