import { createAction } from 'redux-actions';
import { DemoModel } from 'app/models';

export namespace DemoActions {
  export enum Type {
    DEMO_ACTION = 'DEMO_ACTIOM'
  }

  export const demo = createAction<PartialPick<DemoModel, 'text'>>(Type.DEMO_ACTION);
}

export type DemoActions = Omit<typeof DemoActions, 'Type'>;
