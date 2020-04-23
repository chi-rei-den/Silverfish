
/* _BEGIN_TEMPLATE_
{
  "id": "BOT_283",
  "name": [
    "蹦蹦兔",
    "Pogo-Hopper"
  ],
  "text": [
    "<b>战吼：</b>在本局对战中，你每使用一张蹦蹦兔就会使其获得+2/+2。",
    "[x]<b>Battlecry:</b> Gain +2/+2 for\neach other Pogo-Hopper\nyou played this game."
  ],
  "CardClass": "ROGUE",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48471
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BOT_283 : SimTemplate //* 蹦蹦兔 Pogo-Hopper
    {
        //[x]<b>Battlecry:</b> Gain +2/+2 foreach other Pogo-Hopperyou played this game.
        //<b>战吼：</b>在本局对战中，你每使用一张蹦蹦兔就会使其获得+2/+2。
    }
}