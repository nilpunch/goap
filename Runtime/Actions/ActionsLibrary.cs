﻿using System.Collections.Generic;

namespace GOAP.Actions
{
    public class ActionsLibrary : IActionsLibrary
    {
        private readonly List<IAction> _actions = new List<IAction>();

        public IEnumerable<IAction> Actions => _actions;

        public void Add(IAction action)
        {
            _actions.Add(action);
        }
    }
}