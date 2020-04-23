using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_115",
  "name": [
    "乌鸦神像",
    "Raven Idol"
  ],
  "text": [
    "<b>抉择：</b>\n<b>发现</b>一张随从牌；或者<b>发现</b>一张法术牌。",
    "<b>Choose One -</b>\n<b>Discover</b> a minion; or <b>Discover</b> a spell."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 13335
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_115 : SimTemplate //* Raven Idol
    {
        //Choose one - Discover a minion; or Discover a spell.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || p.ownFandralStaghelm > 0 && ownplay)
            {
                p.drawACard(CardIds.Collectible.Neutral.LeperGnome, ownplay, true);
            }

            if (choice == 2 || p.ownFandralStaghelm > 0 && ownplay)
            {
                p.drawACard(CardIds.NonCollectible.Neutral.TheCoin, ownplay, true);
            }
        }
    }
}