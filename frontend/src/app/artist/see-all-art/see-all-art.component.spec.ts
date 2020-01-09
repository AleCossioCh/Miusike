import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeeAllArtComponent } from './see-all-art.component';

describe('SeeAllArtComponent', () => {
  let component: SeeAllArtComponent;
  let fixture: ComponentFixture<SeeAllArtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeeAllArtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeeAllArtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
