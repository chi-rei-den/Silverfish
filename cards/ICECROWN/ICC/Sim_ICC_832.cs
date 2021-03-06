using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_832",
  "name": [
    "污染者玛法里奥",
    "Malfurion the Pestilent"
  ],
  "text": [
    "<b>抉择：</b>召唤两只具有<b>剧毒</b>的蜘蛛；或者召唤两只具有<b>嘲讽</b>的甲虫。",
    "[x]<b>Choose One -</b>\nSummon 2 <b>Poisonous</b>\nSpiders; or 2 Scarabs\nwith <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "HERO",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43417
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_832 : SimTemplate //* Malfurion the Pestilent
    {
        // Choose One - Summon 2 Poisonous Spiders; or 2 Scarabs with Taunt.

        SimCard kidSpider = CardIds.NonCollectible.Druid.MalfurionthePestilent_FrostWidowToken; //Frost Widow
        SimCard kidScarab = CardIds.NonCollectible.Druid.MalfurionthePestilent_ScarabBeetleToken; //Scarab Beetle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Neutral.MalfurionthePestilent_PlagueLord, ownplay); // Plague Lord
            if (ownplay)
            {
                p.ownHero.armor += 5;
            }
            else
            {
                p.enemyHero.armor += 5;
            }

            if (choice == 1 || p.ownFandralStaghelm > 0 && ownplay)
            {
                var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kidSpider, pos, ownplay);
                p.callKid(this.kidSpider, pos, ownplay);
            }

            if (choice == 2 || p.ownFandralStaghelm > 0 && ownplay)
            {
                var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kidScarab, pos, ownplay);
                p.callKid(this.kidScarab, pos, ownplay);
            }
        }
    }
}