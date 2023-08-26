using ShuraGames.BananaMeme.Gameplay.CharacterComponents;
using ShuraGames.BananaMeme.Gameplay.Factories;
using ShuraGames.BananaMeme.Gameplay.Pausing;
using ShuraGames.BananaMeme.Gameplay.PlayerIncarnation;
using ShuraGames.BananaMeme.Gameplay.Updating;
using ShuraProgerGame.UserInputs;
using VContainer;
using VContainer.Unity;

namespace ShuraGames.BananaMeme.Installers.InGameplay
{
    public sealed class GameplayInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Updater>(Lifetime.Singleton);
            builder.Register<Pauser>(Lifetime.Singleton);


            builder.Register<MoveCalculator>(Lifetime.Transient);
            builder.Register<GameplayInput>(Lifetime.Singleton);
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.Register<EnemiesFactory>(Lifetime.Singleton);

            builder.Register<EnemiesService>(Lifetime.Singleton);
            
            builder.Register<PlayerHandler>(Lifetime.Singleton);
            builder.Register<GameplayInitializer>(Lifetime.Singleton);

            // builder.RegisterBuildCallback(container =>
            // {
            //     var someService = container.ResolveNonGeneric(typeof(GameplayInitializer));
            // });
        }
    }
}