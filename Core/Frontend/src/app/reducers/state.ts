import { DemoModel } from 'app/models';
import { RouterState } from 'react-router-redux';

export interface RootState {
  demo: RootState.DemoState;
  router: RouterState
}

export namespace RootState {
  export type DemoState = DemoModel[];
}
