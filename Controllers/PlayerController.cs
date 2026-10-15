using System;
using System.Collections.Generic;
using System.Linq;
using wt_lab3_3mvc_lyashuk.Models;
using wt_lab3_3mvc_lyashuk.Views;

namespace wt_lab3_3mvc_lyashuk.Controllers;

public class PlayerController
{
    private readonly List<Player> _players;
    private readonly PlayerView _view;

    public PlayerController()
    {
        _view = new PlayerView();
        _players = new List<Player>
        {
            new Player { Id = 1, Nickname = "s1mple", Role = "AWPer", Rating = 3200, IsActive = true },
            new Player { Id = 2, Nickname = "ZywOo", Role = "AWPer", Rating = 3150, IsActive = true },
            new Player { Id = 3, Nickname = "b1t", Role = "Rifler", Rating = 2900, IsActive = true },
            new Player { Id = 4, Nickname = "electroNic", Role = "Rifler", Rating = 2850, IsActive = false }
        };
    }

    public void Index()
    {
        _view.ShowPlayers(_players);
    }

    public void Show(int id)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);
        if (player == null)
        {
            _view.ShowMessage("Игрок с таким ID не найден.");
            return;
        }
        _view.ShowPlayer(player);
    }

    public void Add(Player player)
    {
        _players.Add(player);
        _view.ShowMessage("Игрок успешно добавлен в турнир.");
    }

    public void Delete(int id)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);
        if (player == null)
        {
            _view.ShowMessage("Игрок с таким ID не найден.");
            return;
        }
        _players.Remove(player);
        _view.ShowMessage("Игрок успешно удален из турнира.");
    }

    // Дополнительная операция (Пункт 14 методички): Поиск/фильтрация по роли
    public void FilterByRole(string role)
    {
        var result = _players
            .Where(p => p.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
            .ToList();

        _view.ShowMessage($"\n--- Результаты поиска по роли '{role}' ---");
        _view.ShowPlayers(result);
    }

    // Главный цикл меню (Пункт 11 методички)
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n МЕНЮ ТУРНИРА (MVC)");
            Console.WriteLine("1. Показать всех игроков");
            Console.WriteLine("2. Найти игрока по ID");
            Console.WriteLine("3. Добавить игрока");
            Console.WriteLine("4. Удалить игрока");
            Console.WriteLine("5. Фильтр игроков по роли (Доп. функция)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();
            Console.WriteLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;
                case "2":
                    ShowPlayerByUserInput();
                    break;
                case "3":
                    AddPlayerByUserInput();
                    break;
                case "4":
                    DeletePlayerByUserInput();
                    break;
                case "5":
                    FilterByRoleUserInput();
                    break;
                case "0":
                    return;
                default:
                    _view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void ShowPlayerByUserInput()
    {
        Console.Write("Введите ID игрока: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            _view.ShowMessage("Некорректный формат ID.");
            return;
        }
        Show(id);
    }

    private void AddPlayerByUserInput()
    {
        int newId = _players.Count > 0 ? _players.Max(p => p.Id) + 1 : 1;

        Console.Write("Введите никнейм: ");
        string nickname = Console.ReadLine() ?? "";

        Console.Write("Введите роль (AWPer, Rifler, Support, IGL): ");
        string role = Console.ReadLine() ?? "";

        Console.Write("Введите рейтинг (MMR): ");
        if (!int.TryParse(Console.ReadLine(), out int rating))
        {
            _view.ShowMessage("Некорректный рейтинг.");
            return;
        }

        Console.Write("Игрок активен? (1 - да, 0 - нет): ");
        bool isActive = Console.ReadLine() == "1";

        Add(new Player
        {
            Id = newId,
            Nickname = nickname,
            Role = role,
            Rating = rating,
            IsActive = isActive
        });
    }

    private void DeletePlayerByUserInput()
    {
        Console.Write("Введите ID игрока для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            _view.ShowMessage("Некорректный формат ID.");
            return;
        }
        Delete(id);
    }

    private void FilterByRoleUserInput()
    {
        Console.Write("Введите роль для поиска: ");
        string role = Console.ReadLine() ?? "";
        FilterByRole(role);
    }
}