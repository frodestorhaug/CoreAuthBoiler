import * as React from 'react';
import * as style from './style.css';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';
import { RouteComponentProps } from 'react-router';
import { DemoActions } from 'app/actions';
import { RootState } from 'app/reducers';
import { DemoModel } from 'app/models';
import { omit } from 'app/utils';
import { Header } from 'app/components';

const FILTER_VALUES = (Object.keys(DemoModel.Filter) as (keyof typeof DemoModel.Filter)[]).map(
  (key) => DemoModel.Filter[key]
);



export namespace App {
  export interface Props extends RouteComponentProps<void> {
    demo: RootState.DemoState;
    actions: DemoActions;
    filter: DemoModel.Filter;
  }
}

@connect(
  (state: RootState): Pick<App.Props, 'demo' | 'filter'> => {
    const hash = state.router.location && state.router.location.hash.replace('#', '');
    const filter = FILTER_VALUES.find((value) => value === hash) || DemoModel.Filter.SHOW_ALL;
    return { demo: state.demo, filter };
  },
  (dispatch: Dispatch<RootState>): Pick<App.Props, 'actions'> => ({
    actions: bindActionCreators(omit(DemoActions, 'Type'), dispatch)
  })
)
export class App extends React.Component<App.Props> {
  static defaultProps: Partial<App.Props> = {
    filter: DemoModel.Filter.SHOW_ALL
  };

  constructor(props: App.Props, context?: any) {
    super(props, context);
    this.handleClearCompleted = this.handleClearCompleted.bind(this);    
  }

  handleClearCompleted(): void {
    
  }

 

  render() {
    
    return (
      <div className={style.normal}>
        <Header />
        
      </div>
    );
  }
}
