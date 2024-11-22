using ButchersGames;
using CodeBase.GamePlay.Player;
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
        PlayerMarker PlayerMarker { get; }
    }
}