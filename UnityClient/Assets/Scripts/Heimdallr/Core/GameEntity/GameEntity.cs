﻿using Heimdallr.Core.Game.Controllers;
using System;
using UnityEngine;

namespace Heimdallr.Core.Game {
    public class GameEntity : MonoBehaviour, INetworkEntity {

        #region Components
        private GameEntityViewer EntityViewer;
        #endregion

        #region State
        public GameEntityState EntityState { get; private set; }
        public GameEntityData EntityData { get; private set; }
        #endregion

        public void Init(GameEntityData data) {
            EntityData = data;

            var job = DatabaseManager.GetJobById(data.Job);
            EntityViewer = Instantiate<GameEntityViewer>(data.IsMale ? job.Male : job.Female, transform);
            EntityViewer.SetGameEntityData(data);

            gameObject.AddComponent<GameEntityMovementController>();
        }

        public void SetState(GameEntityState state) {
            EntityState = state;
        }

        public void UpdateSprites() {
            throw new NotImplementedException();
        }

        public string GetEntityName() {
            return EntityData.Name;
        }

        public int GetEntityGID() {
            return EntityData.GID;
        }

        public EntityType GetEntityType() {
            return EntityData.EntityType;
        }
    }
}
