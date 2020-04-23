


/* _BEGIN_TEMPLATE_
{
  "id": "BOT_548",
  "name": [
    "奇利亚斯",
    "Zilliax"
  ],
  "text": [
    "<b>磁力，圣盾，嘲讽，吸血，突袭</b>",
    "<b>Magnetic</b>\n<b><b>Divine Shield</b>, <b>Taunt</b>, Lifesteal, Rush</b>"
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 49184
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BOT_548 : SimTemplate //* 奇利亚斯 Zilliax
    {
        //<b>Magnetic</b><b><b>Divine Shield</b>, <b>Taunt</b>, Lifesteal, Rush</b>
        //<b>磁力，圣盾，嘲讽，吸血，突袭</b>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.Magnetic(own);
            }
        }
    }
}