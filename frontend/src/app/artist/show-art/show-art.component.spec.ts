import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowArtComponent } from './show-art.component';

describe('ShowArtComponent', () => {
  let component: ShowArtComponent;
  let fixture: ComponentFixture<ShowArtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShowArtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowArtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
