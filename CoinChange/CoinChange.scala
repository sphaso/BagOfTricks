/*
	Given an amount of money "money" and a series of types of coins "coins"
	return the number of possible combinations of coins that would change
	the initial amount of money
*/

def countChange(money: Int, coins: List[Int]): Int = {
    def change(leCoins: List[Int], index: Int, temp: Int): Int = {
      if(temp == 0) 1
      else if (temp < 0) 0
      else if (index <= 0 && money >= 1) 0
      else change(leCoins, index - 1, temp) + change(leCoins, index, temp - leCoins(index - 1))
    }
    
    change(coins, coins.length, money)
  }
}