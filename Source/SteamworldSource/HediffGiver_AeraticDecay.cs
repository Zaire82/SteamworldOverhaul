using Verse;

namespace SWO_Steamworld
{

    public class HediffGiver_AeraticDecay : HediffGiver
    {
        private HediffGiver_AeraticDecay.HediffType hediffType;
        public  HediffDef cure;
        public float severityPerDay;

        public override void OnIntervalPassed(Pawn pawn, Hediff ignore)
        {
            this.ApplyImplantRejection(pawn, this.hediff);
        }

        public void ApplyImplantRejection(Pawn pawn, HediffDef type)
        {
            if ((this.hediffType != HediffGiver_AeraticDecay.HediffType.clockwork) && (this.hediffType != HediffGiver_AeraticDecay.HediffType.steamwork))
                return;
            if (pawn.health.hediffSet.HasHediff(this.cure))
            {
                if (type == null)
                    return;
                try
                {
                    Hediff firstHediff = pawn.health.hediffSet.GetFirstHediffOfDef(type);
                    pawn.health.RemoveHediff(firstHediff);
                }
                catch { }
            }
            else
                HealthUtility.AdjustSeverity(pawn, type, this.severityPerDay * (1f / 2000f));
        }

        public enum HediffType
        {
            clockwork,
            steamwork,
        }
    }
}

