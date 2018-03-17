
export interface DemoModel {
  id: number;
  text: string;
}

export namespace DemoModel {
  export enum Filter {
    SHOW_ALL = 'all'
  }
}
