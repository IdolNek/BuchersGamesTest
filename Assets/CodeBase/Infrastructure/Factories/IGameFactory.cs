using ButchersGames;
using CodeBase.UI.HUD;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
        LevelManager CreateLevelManager();
        void CreatePlayer(Vector3 position);
    }
}