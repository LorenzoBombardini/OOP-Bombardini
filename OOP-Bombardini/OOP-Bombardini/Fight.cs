using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Bombardini
{
    public class Fight
    {
        public static void Main() { }
        private PlayerCharacter _player;
        public PlayerCharacter Player { get => _player; }

        private EnemyCharacter _enemy;
        public EnemyCharacter Enemy { get => _enemy; }

        private bool playerFail = false;
        private bool enemyFail = false;
        private Move playerLastMove;
        private Move enemyLastMove;
        public int TurnCount { get; set; }

        private Dictionary<Character, Dictionary<Move, int>> mapCharactersMove;
        private Dictionary<Move, int> mapMartyMove;
        private Dictionary<Move, int> mapEnemyMove;

        public Fight(PlayerCharacter player, EnemyCharacter enemy)
        {
            _player = player;
            _enemy = enemy;
            TurnCount = 1;
            CreateHashMap();

        }
        private void EnemyAttack()
        {
            Attack(Enemy.Weapon, EnemyMove(), Player);
        }
        private Move EnemyMove()
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

        public void PlayerAttack(Move inputMove)
        {
            if (IsMoveUsable(Player, inputMove))
            {
                playerLastMove = inputMove;
                Attack(Player.Weapon, inputMove, Enemy);
            }
            EnemyAttack();
        }

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
                if (IsDead((int)Math.Round(weapon.DamageMultiplier * move.Damage), character.Hp))
                {
                    // opponent is DEAD
                    character.Hp = 0;
                    FightWinner();

                }
                else
                {
                    // inflict attack on the opponent
                    character.Hp = (int)Math.Round(character.Hp - (weapon.DamageMultiplier * move.Damage));
                }
            }

            TurnCount++;
        }

        public bool IsDead(int damage, int characterHP)
        {
            return damage >= characterHP;
        }
        public Character FightWinner()
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

        public void SetLastUse(Character character, Move move, int fightTurn)
        {
            mapCharactersMove[character][move] = fightTurn;
        }

        public bool IsMoveUsable(Character character, Move move)
        {
            return move.IsUsable(TurnCount, mapCharactersMove[character][move]);
        }
        public bool GetLastFail(Character character)
        {
            if (character == Player)
            {
                return playerFail;
            }
            return enemyFail;
        }
        public Move GetLastMove(Character character)
        {
            if (character == Player)
            {
                return playerLastMove;
            }
            return enemyLastMove;
        }
        private Character GetOpponent(Character character)
        {
            if (character == Player)
            {
                return Enemy;
            }
            return Player;
        }

        private void SetLastFailCharacter(Character character, bool testFailure)
        {
            if (character == Player)
            {
                playerFail = testFailure;
                return;
            }
            enemyFail = testFailure;
        }
        private void CreateHashMap()
        {
            mapMartyMove = new Dictionary<Move, int>();
            mapEnemyMove = new Dictionary<Move, int>();
            for (int i = 0; i < Weapon.MOVE_LIST_SIZE; i++)
            {
                mapMartyMove.Add(Player.Weapon.GetMoveList()[i], 0);
                mapEnemyMove.Add(Enemy.Weapon.GetMoveList()[i], 0);
            }

            mapCharactersMove = new Dictionary<Character, Dictionary<Move, int>>
            {
                { Player, mapMartyMove },
                { Enemy, mapEnemyMove }
            };
        }




    }
}
