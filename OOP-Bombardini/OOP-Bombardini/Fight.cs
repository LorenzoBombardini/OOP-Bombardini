using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Bombardini
{
    class Fight
    {
        private PlayerCharacter Player { get; }
        private EnemyCharacter Enemy { get; }
        private bool playerFail = false;
        private bool enemyFail = false;
        private Move playerLastMove;
        private Move enemyLastMove;
        private int TurnCount { get; set; }

        private Dictionary<Character, Dictionary<Move, int>> mapCharactersMove ;
        private Dictionary<Move, int> mapMartyMove;
        private Dictionary<Move, int> mapEnemyMove;

        public Fight(PlayerCharacter player, EnemyCharacter enemy)
        {
            Player = player;
            Enemy = enemy;
            TurnCount = 1;
            createHashMap();

        }
        private void enemyAttack()
        {
            attack(Enemy.Weapon, enemyMove(), Player);
        }
        private Move enemyMove()
        {
            Move move;
            Random random = new Random();
            do
            {
                move = Enemy.Weapon.MoveList.ElementAt(random.Next(Enemy.Weapon.MoveList.Count));

            } while (!IsMoveUsable(Enemy, move));
            enemyLastMove = move;
            return move;
        }

        public void playerAttack(Move inputMove)
        {
            if (isMoveUsable(Player, inputMove))
            {
                playerLastMove = inputMove;
                Attack(Player.Weapon, inputMove, Enemy);
            }
            enemyAttack();
        }

        /*
        private void Attack(Weapon weapon, Move move, Character character)
        {
            // check if the move fail
            if (!move.TestFailure())
            {
                SetLastFailCharacter(GetOpponent(character), true);
                SetLastUse(GetOpponent(character), move, TurnCount);

            }
            else
            {
                SetLastFailCharacter(GetOpponent(character), true);
                SetLastUse(GetOpponent(character), move, TurnCount);

                // check if the damage will kill the opponent using isDead function
                if (isDead((int)Math.round((weapon.getDamageMultiplier() * move.getDamage())), character.getHp()))
                {
                    // opponent is DEAD
                    character.setHp(0);
                    fightWinner();

                }
                else
                {
                    // inflict attack on the opponent
                    character.setHp(
                            (int)Math.round((character.getHp() - (weapon.getDamageMultiplier() * move.getDamage()))));
                }
            }

            TurnCount++;
        }
        */

        public bool isDead(int damage, int characterHP)
        {
            return damage >= characterHP;
        }
        public Character fightWinner()
        {
            if (Player.Hp.Equals(0))
            {
                return Enemy;
            }
            if (Enemy.Hp.Equals(0))
            {
                return Player;
            }
            return null;
        }


    }
}
