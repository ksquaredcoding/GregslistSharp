<template>
  <div class="details" v-if="classified?.hasOwnProperty('make')">

    <div class="col-10 m-auto">

      <CarCard :car="classified" />
    </div>

  </div>
  <div class="details" v-else-if="classified?.hasOwnProperty('bedrooms')">

    <div class="col-10 m-auto">

      <HouseCard :house="classified" />
    </div>

  </div>
  <div class="details" v-else-if="classified?.hasOwnProperty('company')">

    <div class="col-10 m-auto">

      <JobCard :job="classified" />
    </div>

  </div>
  <div v-else>
    loading...
  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js';
import CarCard from '../components/CarCard.vue';
import HouseCard from "../components/HouseCard.vue";
import JobCard from "../components/JobCard.vue";
import { classifiedsService } from '../services/ClassifiedsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const route = useRoute();
    const router = useRouter();
    async function getClassifiedById() {
      try {
        await classifiedsService.getClassifiedById(route.params.id);
      }
      catch (error) {
        Pop.error("Sorry that listing no longer exists", "[GettingClassified]");
        router.push({ name: "Home" });
      }
    }
    onMounted(() => {
      getClassifiedById();
    });
    return {
      classified: computed(() => AppState.activeClassified)
    };
  },
  components: { CarCard, HouseCard, JobCard }
}
</script>
