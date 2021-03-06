

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_178",
  "name": [
    "战争古树",
    "Ancient of War"
  ],
  "text": [
    "<b>抉择：</b>\n+5攻击力；或者+5生命值并具有<b>嘲讽</b>。",
    "<b>Choose One -</b>\n+5 Attack; or +5 Health and <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 7,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1035
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_178 : SimTemplate //* ancientofwar
    {
        //Choose One - +5 Attack; or +5 Health and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownFandralStaghelm > 0 && own.own)
            {
                for (var iChoice = 1; iChoice < 3; iChoice++)
                {
                    PenalityManager.Instance.getChooseCard(own.handcard.card, choice).Simulator.onCardPlay(p, own.own, own, iChoice);
                }
            }
            else
            {
                PenalityManager.Instance.getChooseCard(own.handcard.card, choice).Simulator.onCardPlay(p, own.own, own, choice);
            }
        }
    }
}