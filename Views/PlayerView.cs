using System;
using System.Collections.Generic;
using wt_lab3_3mvc_lyashuk.Models;

namespace wt_lab3_3mvc_lyashuk.Views;

public class PlayerView
{
    public void ShowPlayers(List<Player> players)
    {
        Console.WriteLine(" СПИСОК ИГРОКОВ ТУРНИРА ");
        if (players.Count == 0)
        {
            Console.WriteLine("Список игроков пуст.");
            return;
        }

        foreach (var player in players)
        {
            string status = player.IsActive ? "Активен" : "Запасной";
            Console.WriteLine($"{player.Id}. Никнейм: {player.Nickname,-12} | Роль: {player.Role,-8} | MMR: {player.Rating,-5} | Статус: {status}");
        }
    }

    public void ShowPlayer(Player player)
    {
        Console.WriteLine("ИНФОРМАЦИЯ ОБ ИГРОКЕ");
        Console.WriteLine($"ID: {player.Id}");
        Console.WriteLine($"Никнейм: {player.Nickname}");
        Console.WriteLine($"Роль: {player.Role}");
        Console.WriteLine($"Рейтинг (MMR): {player.Rating}");
        Console.WriteLine($"Статус: {(player.IsActive ? "Активен" : "Запасной")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}