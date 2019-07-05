/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SalesDataService } from './sales-data.service';

describe('Service: SalesData', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SalesDataService]
    });
  });

  it('should ...', inject([SalesDataService], (service: SalesDataService) => {
    expect(service).toBeTruthy();
  }));
});
