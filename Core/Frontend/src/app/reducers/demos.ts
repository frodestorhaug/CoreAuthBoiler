import { handleActions } from 'redux-actions';
import { RootState } from './state';
import { DemoActions } from 'app/actions/demo';
import { DemoModel } from 'app/models';

const initialState: RootState.DemoState = [
  {
    id: 1,
    text: 'Use Redux',
  }
];

export const demoReducer = handleActions<RootState.DemoState, DemoModel>(
  {
    [DemoActions.Type.DEMO_ACTION]: (state, action) => {
      if (action.payload && action.payload.text) {
        return [
          {
            id: state.reduce((max, demo) => Math.max(demo.id || 1, max), 0) + 1,
            completed: false,
            text: action.payload.text
          },
          ...state
        ];
      } else {
        return state;
      }
    },    
  },
  initialState
);
