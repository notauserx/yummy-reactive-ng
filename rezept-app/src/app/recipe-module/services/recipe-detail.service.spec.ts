import { TestBed } from '@angular/core/testing';

import { RecipeDetailService } from './recipe-detail.service';

describe('RecipeDetailService', () => {
  let service: RecipeDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecipeDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
