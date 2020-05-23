import { PlayComponent } from "./play.component";
import { Controllers } from "src/controllers/controllers";

describe('PlayComponent', () => {
  let component: PlayComponent;
  let controllers: Controllers;

  beforeEach(() => {
    controllers = new Controllers(jasmine.createSpyObj('http', ['get', 'post', 'put', 'delete']));
    component = new PlayComponent(controllers);
  });

  it('getRouteId - 1', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(1);
  });

  it('getRouteId - 2', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(2);
  });

  it('getRouteId - 3', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(3);
  });

  it('getRouteId - 4', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(4);
  });

  it('getRouteId - 5', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(5);
  });

  it('getRouteId - 6', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(6);
  });

  it('getRouteId - 7', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(7);
  });

  it('getRouteId - 8', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(8);
  });

  it('getRouteId - 9', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(9);
  });

  it('getRouteId - 10', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(10);
  });

  it('getRouteId - 11', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(11);
  });

  it('getRouteId - 12', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(12);
  });

  it('getRouteId - 13', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(13);
  });

  it('getRouteId - 14', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(14);
  });

  it('getRouteId - 15', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(15);
  });

  it('getRouteId - 16', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(16);
  });

  it('getRouteId - 17', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(17);
  });

  it('getRouteId - 18', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(18);
  });

  it('getRouteId - 19', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(19);
  });

  it('getRouteId - 20', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(20);
  });

  it('getRouteId - 21', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(21);
  });

  it('getRouteId - 22', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(22);
  });

  it('getRouteId - 23', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(23);
  });

  it('getRouteId - 24', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(24);
  });

  it('getRouteId - 25', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(25);
  });

  it('getRouteId - 26', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(26);
  });

  it('getRouteId - 27', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(27);
  });

  it('getRouteId - 28', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(28);
  });

  it('getRouteId - 29', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(29);
  });

  it('getRouteId - 30', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(30);
  });

  it('getRouteId - 31', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 0 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(31);
  });

  it('getRouteId - 32', () => {
    let goalAttempt: any = {
      moves: [
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 },
        { directionId: 1 }
      ]
    };
    component.currentGoalAttempt = goalAttempt;
    expect(component.getRouteId()).toBe(32);
  });
});