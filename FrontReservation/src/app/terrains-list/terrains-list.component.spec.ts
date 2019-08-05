import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TerrainsListComponent } from './terrains-list.component';

describe('TerrainsListComponent', () => {
  let component: TerrainsListComponent;
  let fixture: ComponentFixture<TerrainsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TerrainsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TerrainsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
