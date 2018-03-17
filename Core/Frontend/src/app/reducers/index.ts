import { combineReducers, Reducer } from 'redux';
import { RootState } from './state';
import { demoReducer } from './demos';
import { routerReducer, RouterState } from 'react-router-redux';

export { RootState, RouterState };

export const rootReducer: Reducer<RootState> = combineReducers<RootState>({
  demos: demoReducer,
  router: routerReducer
});
